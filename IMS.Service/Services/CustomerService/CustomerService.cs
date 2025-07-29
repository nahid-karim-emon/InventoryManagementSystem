using IMS.Core.Entities;
using IMS.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.Services.CustomerService
{
    public class CustomerService(IUnitOfWorks _unitOfWorks) : ICustomerService
    {
        public async Task AddCustomer(Customer customer)
        {
            await _unitOfWorks.CustomerWriteRepository.AddAsync(customer);
            _unitOfWorks.Complete();
        }

        public async Task<IEnumerable<Customer>> getAllCustomer()
        {
            return await _unitOfWorks.CustomerReadRepository.GetAllAsync();
        }

        public async Task<Customer> getCustomerById(int id)
        {
            return await _unitOfWorks.CustomerReadRepository.GetByIdAsync(id);
        }

        public async Task<Customer> getCustomerByName(string name)
        {
            return await _unitOfWorks.CustomerReadRepository.GetByNameAsync(name);
        }
    }
}
