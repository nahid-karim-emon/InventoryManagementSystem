using IMS.Core.Dto;
using IMS.Core.Entities;
using IMS.Service.Services.ProductService;
using IMS.Service.Services.StockManagerService;
using IMS.Service.Services.WareHouseStockService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;

namespace IMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockManagerController(IStockManagerService stockManagerService, IProductService productService, IWareHouseStockService houseStockService) : ControllerBase
    {
        [HttpGet("pending-check")]
        public async Task<IActionResult> getAllPending()
        {
            var res = await stockManagerService.GetPending();
            if (res == null)
            {
                return BadRequest();
            }
            return Ok(res);
        }

        [HttpGet("all-product-basedOnPurchage/{purchaseId}")]
        public async Task<IActionResult> getAllProduct([FromRoute] int purchaseId)
        {
            var products = await stockManagerService.GetAllItem(purchaseId);
            if (products == null)
                return BadRequest();
            List<ProductOrderItemDto> response = new();
            var total = 0;
            foreach (var item in products)
            {
                var product = await productService.getProductById(item.product_id);
                if (product == null)
                    continue;
                response.Add(new ProductOrderItemDto()
                {
                    ProductName = product.name,
                    Quantity = item.quantity
                });
                total += item.quantity;
            }
            return Ok(new
            {
                Products = response,
                Total_Quantity = total
            });
        }

        [HttpPost("custom-check")]
        public async Task<IActionResult> CustomCheck([FromBody] WarehouseReceivedProductDto model)
        {
            var stock = await houseStockService.getWareHouseStockById(model.warehouse_stock_id);
            if (stock == null)
                return BadRequest();
            var products = await stockManagerService.GetAllItem(stock.purchage_order_id);
            if (products == null)
                return BadRequest();
            var originalOrderMap = products.ToDictionary(item => item.product_id);

            foreach (var item in model.warehouse_products)
            {
                var product = await productService.getProductByName(item.product);
                if(product == null) continue;
                if (!originalOrderMap.TryGetValue(product.id, out var originalOrderItem))continue;
                var original = originalOrderItem.quantity;
                var obj = new WarehouseReceivedProduct()
                {
                    warehouse_stock_id = model.warehouse_stock_id,
                    product_id = product.id,
                    good_product = item.good_product,
                    damaged_product = item.damaged_product,
                    missing_product = original -(item.good_product+item.damaged_product)
                };
                await stockManagerService.AddWarehouseStockProduct(obj);
            }
            await houseStockService.update(model.warehouse_stock_id);
            return Ok(model);
        }

    }
}
