using IMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.Services.WareHouseService
{
    public interface IWareHouseService
    {
        Task<IEnumerable<Warehouse>> getAllWareHouse();
        Task<Warehouse> getWareHouseById(int id);
        Task<Warehouse> getWarehouseByName(string name);
        Task AddWareHouse(Warehouse warehouse);
    }
}
