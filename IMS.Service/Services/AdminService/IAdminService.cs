using IMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.Services.AdminService
{
    public interface IAdminService
    {
        Task<IEnumerable<PurchageOrder>> GetPurchages();
        Task AddWarehouseStock(WarehouseStock warehouseStock);
    }
}
