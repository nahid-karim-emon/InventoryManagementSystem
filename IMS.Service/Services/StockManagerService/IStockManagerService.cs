using IMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.Services.StockManagerService
{
    public interface IStockManagerService
    {
        Task<IEnumerable<WarehouseStock>> GetPending();
        Task AddWarehouseStockProduct(WarehouseReceivedProduct receivedProduct);
        Task<IEnumerable<PurchaseOrderItem>> GetAllItem(int id);
    }
}
