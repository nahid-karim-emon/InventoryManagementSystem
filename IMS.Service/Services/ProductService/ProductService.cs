using Dapper;
using IMS.Core.Caching;
using IMS.Core.Entities;
using IMS.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.Services.ProductService
{
    public class ProductService(IUnitOfWorks _unitOfWorks, IRedisCacheService _cache) : IProductService
    {
        public async Task AddProduct(Product product)
        {
            await _unitOfWorks.ProductWriteRepository.AddAsync(product);
            _unitOfWorks.Complete();
        }

        public async Task<IEnumerable<Product>> getAllProduct()
        {
            var products = await _cache.GetAsync<IEnumerable<Product>>("all_products");
            if (products != null)
            {
                return products;
            }
            products = await _unitOfWorks.ProductReadRepository.GetAllAsync();
            await _cache.SetAsync("all_products", products);
            return products;
        }

        public async Task<Product> getProductById(int id)
        {
            var allProducts = await _cache.GetAsync<IEnumerable<Product>>("all_products");

            if (allProducts != null)
            {
                var productFromCache = allProducts.FirstOrDefault(p => p.id == id);
                if (productFromCache != null)
                {
                    return productFromCache;
                }
            }
            return await _unitOfWorks.ProductReadRepository.GetByIdAsync(id);
        }

        public async Task<Product> getProductByName(string name)
        {
            return await _unitOfWorks.ProductReadRepository.GetByNameAsync(name);
        }
    }
}
