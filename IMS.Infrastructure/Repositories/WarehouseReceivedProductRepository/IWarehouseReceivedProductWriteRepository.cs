using IMS.Core.CoreInterface;
using IMS.Core.Entities;
using IMS.Infrastructure.Core;
using IMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repositories.WarehouseReceivedProductRepository
{
    public interface IWarehouseReceivedProductWriteRepository : IWriteRepository<WarehouseReceivedProduct>
    {
    }

    public class WarehouseReceivedProductWriteRepository : WriteRepository<WarehouseReceivedProduct>, IWarehouseReceivedProductWriteRepository
    {
        public WarehouseReceivedProductWriteRepository(ApplicationWriteDbContext writeContext) : base(writeContext)
        {
        }
    }
}
