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

namespace IMS.Infrastructure.Repositories.WarehouseReceivedProductRepository
{
    public interface IWarehouseReceivedProductReadRepository : IReadRepository<WarehouseReceivedProduct>
    {
    }

    public class WarehouseReceivedProductReadRepository : ReadRepository<WarehouseReceivedProduct>, IWarehouseReceivedProductReadRepository
    {
        public WarehouseReceivedProductReadRepository(ApplicationReadDbContext readContext) : base(readContext)
        {
        }
    }
}
