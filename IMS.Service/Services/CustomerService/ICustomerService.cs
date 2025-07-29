using IMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.Services.CustomerService
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> getAllCustomer();
        Task<Customer> getCustomerById(int id);
        Task<Customer> getCustomerByName(string name);
        Task AddCustomer(Customer customer);
    }
}
