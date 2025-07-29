using IMS.Core.CoreInterface;
using IMS.Core.Entities;
using IMS.Infrastructure.Core;
using IMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repositories.PurchageOrderRepository
{
    public interface IPurchageOrderWriteRepository : IWriteRepository<PurchageOrder>
    {
    }

    public class PurchageOrderWriteRepository : WriteRepository<PurchageOrder>, IPurchageOrderWriteRepository
    {
        public PurchageOrderWriteRepository(ApplicationWriteDbContext writeContext) : base(writeContext)
        {
        }
    }
}
