using IMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.Services.SellerOrderItemService
{
    public interface ISellerOrderItemService
    {
        Task addSellerOrderItem(SellerOrderItem orderItem);
        Task<IEnumerable<SellerOrderItem>> getAllOrder(int id);
        Task<int> GetTotalProductSalesByWarehouse(int warehouseId, int productId);
    }
}
