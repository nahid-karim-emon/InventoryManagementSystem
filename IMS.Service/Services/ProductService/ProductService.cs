using Dapper;
using IMS.Core.Entities;
using IMS.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.Services.ProductService
{
    public class ProductService(IUnitOfWorks _unitOfWorks) : IProductService
    {
        public async Task AddProduct(Product product)
        {
            await _unitOfWorks.ProductWriteRepository.AddAsync(product);
            _unitOfWorks.Complete();
        }

        public async Task<IEnumerable<Product>> getAllProduct()
        {
            return await _unitOfWorks.ProductReadRepository.GetAllAsync();
        }

        public async Task<Product> getProductById(int id)
        {
            return await _unitOfWorks.ProductReadRepository.GetByIdAsync(id);
        }

        public async Task<Product> getProductByName(string name)
        {
            return await _unitOfWorks.ProductReadRepository.GetByNameAsync(name);
        }
    }
}
