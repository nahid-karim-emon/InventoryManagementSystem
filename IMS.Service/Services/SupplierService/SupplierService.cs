using IMS.Core.Entities;
using IMS.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.Services.SupplierService
{
    public class SupplierService(IUnitOfWorks _unitOfWorks) : ISupplierService
    {
        public async Task AddSupplier(Supplier supplier)
        {
            await _unitOfWorks.SupplierWriteRepository.AddAsync(supplier);
            _unitOfWorks.Complete();
        }

        public async Task<IEnumerable<Supplier>> getAllSupplier()
        {
            return await _unitOfWorks.SupplierReadRepository.GetAllAsync();
        }

        public async Task<Supplier> getSupplierById(int id)
        {
            return await _unitOfWorks.SupplierReadRepository.GetByIdAsync(id);
        }

        public async Task<Supplier> getSupplierByName(string name)
        {
            return await _unitOfWorks.SupplierReadRepository.GetByNameAsync(name);
        }
    }
}
