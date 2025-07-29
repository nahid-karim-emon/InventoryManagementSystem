using IMS.Core.CoreInterface;
using IMS.Core.Entities;
using IMS.Infrastructure.Core;
using IMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repositories.PurchageOrderItemRepository
{
    public interface IPurchageOrderItemWriteRepository : IWriteRepository<PurchaseOrderItem>
    {
    }

    public class PurchageOrderItemWriteRepository : WriteRepository<PurchaseOrderItem>, IPurchageOrderItemWriteRepository
    {
        public PurchageOrderItemWriteRepository(ApplicationWriteDbContext writeContext) : base(writeContext)
        {
        }
    }
}
