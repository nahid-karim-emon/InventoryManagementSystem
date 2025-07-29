using IMS.Core.Entities;
using IMS.Infrastructure.Core;
using IMS.Infrastructure.Data;
using static IMS.Core.CoreInterface.IReadRepository;

namespace IMS.Infrastructure.Repositories.BrandRepository
{
    public interface IBrandReadRepository : IReadRepository<Brand>
    {
    }

    public class BrandReadRepository : ReadRepository<Brand>, IBrandReadRepository
    {
        public BrandReadRepository(ApplicationReadDbContext readContext) : base(readContext)
        {
        }
    }
}
