using IMS.Core.Entities;
using IMS.Infrastructure.Core;
using IMS.Infrastructure.Data;
using static IMS.Core.CoreInterface.IReadRepository;

namespace IMS.Infrastructure.Repositories.ProductCategoryRepository
{
    public interface IProductCategoryReadRepository : IReadRepository<ProductCategory>
    {
    }

    public class ProductCategoryReadRepository : ReadRepository<ProductCategory>, IProductCategoryReadRepository
    {
        public ProductCategoryReadRepository(ApplicationReadDbContext readContext) : base(readContext)
        {
        }
    }
}
