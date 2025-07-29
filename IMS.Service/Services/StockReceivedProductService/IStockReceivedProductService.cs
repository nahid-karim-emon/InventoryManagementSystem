using IMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.Services.StockReceivedProductService
{
    public interface IStockReceivedProductService
    {
        Task<IEnumerable<WarehouseReceivedProduct>> GetProducts(int id);
        Task<int> GetGoodProductCountByWarehouseAndProduct(int warehouseId, int productId);
    }
}
