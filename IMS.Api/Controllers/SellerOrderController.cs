using IMS.Core.Dto;
using IMS.Core.Entities;
using IMS.Service.Services.CustomerService;
using IMS.Service.Services.ProductService;
using IMS.Service.Services.SellerOrderItemService;
using IMS.Service.Services.SellerOrderService;
using IMS.Service.Services.StockReceivedProductService;
using IMS.Service.Services.WareHouseService;
using IMS.Service.Services.WareHouseStockService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerOrderController(IStockReceivedProductService stockReceivedProductService, IWareHouseService wareHouse, IWareHouseStockService stockService,IProductService productService, ISellerOrderService sellerOrderService, ISellerOrderItemService sellerOrderItemService, ICustomerService customerService) : ControllerBase
    {
        [HttpPost("Seller-order")]
        public async Task<IActionResult> SellerOrder([FromBody] SellerOrderDto orderDto)
        {
            var customer = await customerService.getCustomerByName(orderDto.customer_name);
            if (customer == null) {
                return BadRequest("Invalid Customer!");
            }
            var warehouse = await wareHouse.getWarehouseByName(orderDto.warehouse_name);
            if (warehouse == null)
            {
                return BadRequest("Invalid WareHouse!");
            }
            var sellerOrder = new SellerOrder()
            {
                customer_id = customer.id,
                warehouse_id = warehouse.id,
                created = DateTime.UtcNow,
                status = "Done",
                name = customer.name
            };
            var sellerOrderId = await sellerOrderService.AddSellerOrder(sellerOrder);
            var totalItem = 0;
            var totalCost = 0;
            List<ProductOrderItemDto> items = new List<ProductOrderItemDto>();
            foreach (var item in orderDto.Products)
            {
                var product = await productService.getProductByName(item.ProductName);
                if (product == null)
                {
                    continue;
                }
                var stock = await stockReceivedProductService.GetGoodProductCountByWarehouseAndProduct(warehouse.id, product.id);
                if (stock < item.Quantity)
                {
                    return BadRequest("Out of stock!");
                }
                var order = new SellerOrderItem()
                {
                    seller_order_id = sellerOrderId,
                    product_id = product.id,
                    quantity = item.Quantity,
                };

                items.Add(item);
                await sellerOrderItemService.addSellerOrderItem(order);
                totalItem += item.Quantity;
                totalCost += item.Quantity * product.unit_cost;
            }

            var response = new SellerOrderInfoDto()
            {
                CustomerName = orderDto.customer_name,
                WareHouseName = orderDto.warehouse_name,
                Products = items,
                TotalProducts = totalItem,
                TotalCost = totalCost
            };

            return Ok(response);
        }
    }
}
