using IMS.Core.CoreInterface;
using IMS.Core.Entities;
using IMS.Infrastructure.Core;
using IMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repositories.ProductCategoryRepository
{
    public interface IProductCategoryWriteRepository : IWriteRepository<ProductCategory>
    {
    }

    public class ProductCategoryWriteRepository : WriteRepository<ProductCategory>, IProductCategoryWriteRepository
    {
        public ProductCategoryWriteRepository(ApplicationWriteDbContext writeContext) : base(writeContext)
        {
        }
    }
}
