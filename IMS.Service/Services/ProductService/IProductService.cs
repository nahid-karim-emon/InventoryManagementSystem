using IMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.Services.ProductService
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> getAllProduct();
        Task<Product> getProductById(int id);
        Task<Product> getProductByName(string name);
        Task AddProduct(Product product);
    }
}
