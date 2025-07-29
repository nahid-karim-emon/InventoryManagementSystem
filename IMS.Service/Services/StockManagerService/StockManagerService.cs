using Dapper;
using IMS.Core.Entities;
using IMS.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.Services.StockManagerService
{
    public class StockManagerService(IUnitOfWorks unitOfWorks, IReadDbConnectionFactory _readConnectionFactory, IWriteDbConnectionFactory _writeConnectionFactory) : IStockManagerService
    {
        public async Task AddWarehouseStockProduct(WarehouseReceivedProduct receivedProduct)
        {
            await unitOfWorks.WarehouseReceivedProductWriteRepository.AddAsync(receivedProduct);
            unitOfWorks.Complete();
        }

        public async Task<IEnumerable<PurchaseOrderItem>> GetAllItem(int id)
        {
            var sql = @"SELECT * FROM ""PurchaseOrdersItem"" WHERE ""purchage_order_id"" = @Id";
            using var connection = _readConnectionFactory.CreateConnection();
            return await connection.QueryAsync<PurchaseOrderItem>(sql, new { Id = id });
        }

        public async Task<IEnumerable<WarehouseStock>> GetPending()
        {
            var sql = @"SELECT * FROM ""WarehouseStocks"" WHERE ""status"" = @status";
            using var connection = _readConnectionFactory.CreateConnection();
            return await connection.QueryAsync<WarehouseStock>(sql, new { status = "Pending" });
        }
    }
}
