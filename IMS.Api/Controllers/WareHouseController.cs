using IMS.Core.Dto;
using IMS.Core.Entities;
using IMS.Service.Services.ProductService;
using IMS.Service.Services.PurchageOrderService;
using IMS.Service.Services.SellerOrderItemService;
using IMS.Service.Services.StockReceivedProductService;
using IMS.Service.Services.SupplierService;
using IMS.Service.Services.WareHouseService;
using IMS.Service.Services.WareHouseStockService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace IMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WareHouseController(ISellerOrderItemService sellerOrderItemService, ISupplierService supplierService, IPurchageOrderService purchageOrderService,IStockReceivedProductService stockReceivedProductService, IWareHouseService  _wareHouseService,IWareHouseStockService stockService, IProductService productService) : ControllerBase
    {
        [HttpGet("get-all-wareHouse")]
        public async Task<IActionResult> GetAllWareHouse()
        {
            var res = await _wareHouseService.getAllWareHouse();
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpGet("wareHouseById/{id}")]
        public async Task<IActionResult> GetWareHouseById([FromRoute] int id)
        {
            var res = await _wareHouseService.getWareHouseById(id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpPost("add-wareHouse")]
        public async Task<IActionResult> AddWareHouse([FromBody] WarehouseDto model)
        {
            var obj = new Warehouse()
            {
                name = model.name,
                location = model.location
            };
            await _wareHouseService.AddWareHouse(obj);
            return Ok(obj);
        }

        [HttpGet("WareHouseStock/{warehouse}")]
        public async Task<IActionResult> wareHouseStock([FromRoute] string warehouse)
        {
            var ware = await _wareHouseService.getWarehouseByName(warehouse);
            var stock = await stockService.getWareHouseStockByWId(ware.id);
            if(ware  == null || stock == null)
            {
                return NotFound();
            }
            List<WareHouseStockInfo> stockInfos = new List<WareHouseStockInfo>();
            var stockIds = stock.Select(s => s.id).ToList();
                var recPro = await stockReceivedProductService.GetProducts(stockIds);
                var obj = new WareHouseStockInfo();
                List<WarehouseReceivedProductItemDto> products = new();
                foreach(var pro in recPro)
                {
                    var product = await productService.getProductById(pro.product_id);
                    var totalSell = await sellerOrderItemService.GetTotalProductSalesByWarehouse(ware.id,product.id);
                    var obj1 = new WarehouseReceivedProductItemDto()
                    {
                        product = product.name,
                        good_product = pro.total_good_product,
                        damaged_product = pro.total_damaged_product,
                        currentInStock = pro.total_good_product - totalSell
                    };
                    products.Add(obj1);
                }
                obj.Products = products;
                stockInfos.Add(obj);
            var response = new WareHouseDetailsDto()
            {
                WareHouse = ware.name,
                wareHouseStockInfos = stockInfos,
            };
            return Ok(response);
        }
    }
}
