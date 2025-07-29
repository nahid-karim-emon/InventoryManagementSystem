using IMS.Core.CoreInterface;
using IMS.Core.Entities;
using IMS.Infrastructure.Core;
using IMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repositories.WareHouseStockRepository
{
    public interface IWareHouseStockWriteRepository : IWriteRepository<WarehouseStock>
    {
    }

    public class WareHouseStockWriteRepository : WriteRepository<WarehouseStock>, IWareHouseStockWriteRepository
    {
        public WareHouseStockWriteRepository(ApplicationWriteDbContext writeContext) : base(writeContext)
        {
        }
    }
}
