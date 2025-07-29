using IMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.Services.WareHouseStockService
{
    public interface IWareHouseStockService
    {
        Task<IEnumerable<WarehouseStock>> getAllWareHouseStock();
        Task<WarehouseStock> getWareHouseStockById(int id);
        Task<IEnumerable<WarehouseStock>> getWareHouseStockByWId(int id);
        Task<WarehouseStock> GetWarehouseStockbyProductId(int w_id, int p_id);
        Task update(int id);
        Task addWStock(WarehouseStock warehouseStock);
    }
}
