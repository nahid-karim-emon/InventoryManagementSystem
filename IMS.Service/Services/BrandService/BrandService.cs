using IMS.Core.Entities;
using IMS.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.Services.BrandService
{
    public class BrandService(IUnitOfWorks _unitOfWorks) : IBrandService
    {
        public async Task AddBrand(Brand brand)
        {
            await _unitOfWorks.BrandWriteRepository.AddAsync(brand);
            _unitOfWorks.Complete();
        }

        public async Task<IEnumerable<Brand>> getAllBrand()
        {
            return await _unitOfWorks.BrandReadRepository.GetAllAsync();
        }

        public async Task<Brand> getBrandById(int id)
        {
            return await _unitOfWorks.BrandReadRepository.GetByIdAsync(id);
        }
        public async Task<Brand> getBrandByName(string name)
        {
            return await _unitOfWorks.BrandReadRepository.GetByNameAsync(name);
        }
    }
}
