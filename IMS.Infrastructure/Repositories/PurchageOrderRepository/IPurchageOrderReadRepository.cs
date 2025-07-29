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

namespace IMS.Infrastructure.Repositories.PurchageOrderRepository
{
    public interface IPurchageOrderReadRepository : IReadRepository<PurchageOrder>
    {
    }

    public class PurchageOrderReadRepository : ReadRepository<PurchageOrder>, IPurchageOrderReadRepository
    {
        public PurchageOrderReadRepository(ApplicationReadDbContext readContext) : base(readContext)
        {
        }
    }
}
