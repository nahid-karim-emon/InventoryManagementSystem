using IMS.Core.CoreInterface;
using IMS.Core.Entities;
using IMS.Infrastructure.Core;
using IMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repositories.BrandRepository
{
    public interface IBrandWriteRepository : IWriteRepository<Brand>
    {
    }

    public class BrandWriteRepository : WriteRepository<Brand>, IBrandWriteRepository
    {
        public BrandWriteRepository(ApplicationWriteDbContext writeContext) : base(writeContext)
        {
        }
    }
}
