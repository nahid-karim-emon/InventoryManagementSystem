using IMS.Core.Dto;
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
        Task<IEnumerable<WarehouseProductSummaryDto>> GetProducts(IEnumerable<int> stockIds);
        Task<int> GetGoodProductCountByWarehouseAndProduct(int warehouseId, int productId);
    }
}
