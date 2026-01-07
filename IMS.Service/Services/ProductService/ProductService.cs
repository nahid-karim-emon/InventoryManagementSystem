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
        private const string ProductsCacheKey = "products_hash";

        public async Task AddProduct(Product product)
        {
            await _unitOfWorks.ProductWriteRepository.AddAsync(product);
            _unitOfWorks.Complete();

            await _cache.HashSetAsync(ProductsCacheKey, product.id.ToString(), product);
        }

        public async Task<IEnumerable<Product>> getAllProduct()
        {
            var products = await _cache.HashGetAllAsync<Dictionary<string, Product>>(ProductsCacheKey);
            if (products != null && products.Count > 0)
            {
                return products.Values;
            }

            var dbProducts = await _unitOfWorks.ProductReadRepository.GetAllAsync();
            
            foreach (var product in dbProducts)
            {
                await _cache.HashSetAsync(ProductsCacheKey, product.id.ToString(), product);
            }

            return dbProducts;
        }

        public async Task<Product> getProductById(int id)
        {
            var products = await _cache.HashGetAllAsync<Dictionary<string, Product>>(ProductsCacheKey);

            if (products != null && products.TryGetValue(id.ToString(), out var productFromCache))
            {
                return productFromCache;
            }

            var product = await _unitOfWorks.ProductReadRepository.GetByIdAsync(id);
            
            if (product != null)
            {
                await _cache.HashSetAsync(ProductsCacheKey, id.ToString(), product);
            }

            return product;
        }

        public async Task<Product> getProductByName(string name)
        {
            return await _unitOfWorks.ProductReadRepository.GetByNameAsync(name);
        }
    }
}
