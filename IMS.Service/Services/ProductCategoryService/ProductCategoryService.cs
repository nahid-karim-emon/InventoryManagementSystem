using IMS.Core.Entities;
using IMS.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.Services.ProductCategoryService
{
    public class ProductCategoryService(IUnitOfWorks _unitOfWorks) : IProductCategoryService
    {
        public async Task AddProductCategory(ProductCategory productCategory)
        {
            await _unitOfWorks.ProductCategoryWriteRepository.AddAsync(productCategory);
            _unitOfWorks.Complete();
        }

        public async Task<IEnumerable<ProductCategory>> getAllProductCategory()
        {
            return await _unitOfWorks.ProductCategoryReadRepository.GetAllAsync();
        }

        public async Task<ProductCategory> getProductCategoryById(int id)
        {
            return await _unitOfWorks.ProductCategoryReadRepository.GetByIdAsync(id);
        }
        public async Task<ProductCategory> getProductCategoryByName(string name)
        {
            return await _unitOfWorks.ProductCategoryReadRepository.GetByNameAsync(name);
        }
    }
}
