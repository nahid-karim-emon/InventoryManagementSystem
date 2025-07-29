using IMS.Core.CoreInterface;
using IMS.Core.Entities;
using IMS.Infrastructure.Core;
using IMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repositories.CustomerRepository
{
    public interface ICustomerWriteRepository : IWriteRepository<Customer>
    {
    }

    public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(ApplicationWriteDbContext writeContext) : base(writeContext)
        {
        }
    }
}
