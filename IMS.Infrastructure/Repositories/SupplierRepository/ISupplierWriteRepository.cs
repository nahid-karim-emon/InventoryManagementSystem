using IMS.Core.CoreInterface;
using IMS.Core.Entities;
using IMS.Infrastructure.Core;
using IMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repositories.SupplierRepository
{
    public interface ISupplierWriteRepository : IWriteRepository<Supplier>
    {
    }

    public class SupplierWriteRepository : WriteRepository<Supplier>, ISupplierWriteRepository
    {
        public SupplierWriteRepository(ApplicationWriteDbContext writeContext) : base(writeContext)
        {
        }
    }
}
