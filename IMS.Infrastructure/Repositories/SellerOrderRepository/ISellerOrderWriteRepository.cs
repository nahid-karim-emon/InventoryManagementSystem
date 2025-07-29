using IMS.Core.CoreInterface;
using IMS.Core.Entities;
using IMS.Infrastructure.Core;
using IMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repositories.SellerOrderRepository
{
    public interface ISellerOrderWriteRepository : IWriteRepository<SellerOrder>
    {
    }

    public class SellerOrderWriteRepository : WriteRepository<SellerOrder>, ISellerOrderWriteRepository
    {
        public SellerOrderWriteRepository(ApplicationWriteDbContext writeContext) : base(writeContext)
        {
        }
    }
}
