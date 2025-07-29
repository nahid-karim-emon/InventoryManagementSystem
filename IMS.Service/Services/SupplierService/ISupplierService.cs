using IMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.Services.SupplierService
{
    public interface ISupplierService
    {
        Task<IEnumerable<Supplier>> getAllSupplier();
        Task<Supplier> getSupplierById(int id);
        Task<Supplier> getSupplierByName(string name);
        Task AddSupplier(Supplier supplier);
    }
}
