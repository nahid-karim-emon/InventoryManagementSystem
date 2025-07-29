using IMS.Core.CoreInterface;
using IMS.Core.Entities;
using IMS.Infrastructure.Core;
using IMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IMS.Core.CoreInterface.IReadRepository;

namespace IMS.Infrastructure.Repositories.ProductRepository
{
    public interface IProductReadRepository : IReadRepository<Product>
    {
    }

    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(ApplicationReadDbContext readContext) : base(readContext)
        {
        }
    }
}
