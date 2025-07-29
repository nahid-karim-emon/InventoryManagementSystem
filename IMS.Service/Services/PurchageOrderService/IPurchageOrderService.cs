using IMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.Services.PurchageOrderService
{
    public interface IPurchageOrderService
    {
        Task<IEnumerable<PurchageOrder>> getAllPurchageOrder();
        Task<PurchageOrder> getPurchageOrderById(int id);
        Task<int> AddPurchageOrder(PurchageOrder purchageOrder);
        Task UpdatePurchageStatus(int id);
    }
}
