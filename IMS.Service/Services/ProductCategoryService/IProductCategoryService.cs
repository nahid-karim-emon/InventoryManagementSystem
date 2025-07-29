using IMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.Services.ProductCategoryService
{
    public interface IProductCategoryService
    {
        Task<IEnumerable<ProductCategory>> getAllProductCategory();
        Task<ProductCategory> getProductCategoryById(int id);
        Task<ProductCategory> getProductCategoryByName(string name);
        Task AddProductCategory(ProductCategory productCategory);
    }
}
