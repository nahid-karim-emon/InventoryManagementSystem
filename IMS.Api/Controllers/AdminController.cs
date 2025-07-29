using IMS.Core.Dto;
using IMS.Core.Entities;
using IMS.Service.Services.AdminService;
using IMS.Service.Services.PurchageOrderService;
using IMS.Service.Services.WareHouseService;
using IMS.Service.Services.WareHouseStockService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController(IAdminService adminService,IWareHouseService wareHouse,IWareHouseStockService houseStockService, IPurchageOrderService purchageOrderService) : ControllerBase
    {
        [HttpGet("pending-purchase-order")]
        public async Task<IActionResult> getPendingPurchaseOrder()
        {
            var res = await adminService.GetPurchages();
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpPost("approve-order")]
        public async Task<IActionResult> ApproveOrder([FromBody] ApproveOrderDto model)
        {
            var warehouse = await wareHouse.getWarehouseByName(model.warehouse);
            if (warehouse == null)
            {
                return NotFound();
            }
            var stock = new WarehouseStock()
            {
                warehouse_id = warehouse.id,
                purchage_order_id = model.purchase_order_id,
                status = "Pending",
                createdAt = DateTime.UtcNow
            };
            await purchageOrderService.UpdatePurchageStatus(model.purchase_order_id);
            await houseStockService.addWStock(stock);


            return Ok("Succefully transfer to the warehouse!");
        }
    }
}
