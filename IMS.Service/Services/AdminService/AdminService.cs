using Dapper;
using IMS.Core.Entities;
using IMS.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.Services.AdminService
{
    public class AdminService(IUnitOfWorks unitOfWorks, IReadDbConnectionFactory _readConnectionFactory, IWriteDbConnectionFactory _writeConnectionFactory) : IAdminService
    {
        public async Task AddWarehouseStock(WarehouseStock warehouseStock)
        {
            await unitOfWorks.WareHouseStockWriteRepository.AddAsync(warehouseStock);
            unitOfWorks.Complete();
        }

        public async Task<IEnumerable<PurchageOrder>> GetPurchages()
        {
            var sql = @"SELECT * FROM ""PurchageOrders"" WHERE ""status"" = @status";
            using var connection = _readConnectionFactory.CreateConnection();
            return await connection.QueryAsync<PurchageOrder>(sql, new { status = "Pending" });
        }
    }
}
