using IMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.Services.SellerOrderService
{
    public interface ISellerOrderService
    {
        Task<IEnumerable<SellerOrder>> getAllSellerOrder();
        Task<SellerOrder> getSellerOrderById(int id);
        Task<int> AddSellerOrder(SellerOrder sellerOrder);
    }
}
