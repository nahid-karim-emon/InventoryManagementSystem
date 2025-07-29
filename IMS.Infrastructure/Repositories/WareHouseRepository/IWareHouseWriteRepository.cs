using IMS.Core.CoreInterface;
using IMS.Core.Entities;
using IMS.Infrastructure.Core;
using IMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repositories.WareHouseRepository
{
    public interface IWareHouseWriteRepository : IWriteRepository<Warehouse>
    {
    }

    public class WareHouseWriteRepository : WriteRepository<Warehouse>, IWareHouseWriteRepository
    {
        public WareHouseWriteRepository(ApplicationWriteDbContext writeContext) : base(writeContext)
        {
        }
    }
}
