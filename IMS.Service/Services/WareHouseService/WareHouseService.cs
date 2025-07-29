using IMS.Core.Entities;
using IMS.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.Services.WareHouseService
{
    public class WareHouseService(IUnitOfWorks _unitOfWorks) : IWareHouseService
    {
        public async Task AddWareHouse(Warehouse warehouse)
        {
            await _unitOfWorks.WareHouseWriteRepository.AddAsync(warehouse);
            _unitOfWorks.Complete();
        }

        public async Task<IEnumerable<Warehouse>> getAllWareHouse()
        {
            return await _unitOfWorks.WareHouseReadRepository.GetAllAsync();
        }

        public async Task<Warehouse> getWareHouseById(int id)
        {
            return await _unitOfWorks.WareHouseReadRepository.GetByIdAsync(id);
        }

        public async Task<Warehouse> getWarehouseByName(string name)
        {
            return await _unitOfWorks.WareHouseReadRepository.GetByNameAsync(name);
        }
    }
}
