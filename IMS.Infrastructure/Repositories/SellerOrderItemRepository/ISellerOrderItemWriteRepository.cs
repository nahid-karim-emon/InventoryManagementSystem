using IMS.Core.CoreInterface;
using IMS.Core.Entities;
using IMS.Infrastructure.Core;
using IMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repositories.SellerOrderItemRepository
{
    public interface ISellerOrderItemWriteRepository : IWriteRepository<SellerOrderItem>
    {
    }

    public class SellerOrderItemWriteRepository : WriteRepository<SellerOrderItem>, ISellerOrderItemWriteRepository
    {
        public SellerOrderItemWriteRepository(ApplicationWriteDbContext writeContext) : base(writeContext)
        {
        }
    }
}
