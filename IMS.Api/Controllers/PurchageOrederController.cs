using IMS.Core.Dto;
using IMS.Core.Entities;
using IMS.Service.Services.ProductOrderItemService;
using IMS.Service.Services.ProductService;
using IMS.Service.Services.PurchageOrderService;
using IMS.Service.Services.SupplierService;
using IMS.Service.Services.WareHouseService;
using IMS.Service.Services.WareHouseStockService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchageOrederController(IPurchageOrderService purchageOrderService, IWareHouseStockService stockService, IWareHouseService wareHouseService, IProductOrderItemService productOrderItemService, IProductService productService, ISupplierService supplierService) : ControllerBase
    {
        [HttpPost("create-purchase")]
        public async Task<IActionResult> purchage([FromBody]PurchageOrderDto purchageOrder)
        {
            var supplier = await supplierService.getSupplierByName(purchageOrder.SupplierName);
            if (supplier == null)
            {
                return NotFound("No Supplier Found!");
            }
            var purchase = new PurchageOrder()
            {
                supplier_id = supplier.id,
                created = DateTime.UtcNow,
                status = "Pending",
                name = null
            };
            var purchage_order_id = 0;
            purchage_order_id = await purchageOrderService.AddPurchageOrder(purchase);
            var total = 0;
            var cost = 0;
            foreach (var order in purchageOrder.Products)
            {
                var product = await productService.getProductByName(order.ProductName);
                if (product == null)
                {
                    return Ok(product);
                }

                var orderItem = new PurchaseOrderItem()
                {
                    purchage_order_id = purchage_order_id,
                    product_id = product.id,
                    quantity = order.Quantity,
                };
                total += order.Quantity;
                cost += order.Quantity * product.unit_cost;
                await productOrderItemService.addPurchaseOrderItem(orderItem);
            }

            var response = new PurchageOrderInfoDto()
            {
                PurchaseOrderId = purchage_order_id,
                Status = purchase.status,
                TotalCost = cost,
                TotalItems = total
            };
            return Ok(response);
        }
    }
}
