using Dapper;
using IMS.Core.Entities;
using IMS.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.Services.WareHouseStockService
{
    public class WareHouseStockService(IUnitOfWorks unitOfWorks, IReadDbConnectionFactory _readConnectionFactory, IWriteDbConnectionFactory _writeConnectionFactory) : IWareHouseStockService
    {
        public async Task addWStock(WarehouseStock warehouseStock)
        {
            await unitOfWorks.WareHouseStockWriteRepository.AddAsync(warehouseStock);
            unitOfWorks.Complete();
        }

        public async Task<IEnumerable<WarehouseStock>> getAllWareHouseStock()
        {
            var sql = @"SELECT * FROM ""WarehouseStocks""";
            using var connection = _readConnectionFactory.CreateConnection();
            return await connection.QueryAsync<WarehouseStock>(sql);
        }

        public async Task<WarehouseStock> getWareHouseStockById(int id)
        {
            var sql = @"SELECT * FROM ""WarehouseStocks"" WHERE ""id"" = @Id";
            using var connection = _readConnectionFactory.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<WarehouseStock>(sql, new { Id = id });
        }

        public async Task<WarehouseStock> GetWarehouseStockbyProductId(int w_id, int p_id)
        {
            var sql = @"SELECT * FROM ""WarehouseStocks"" WHERE ""warehouse_id"" = @WarehouseId AND ""product_id"" = @ProductId";
            using var connection = _readConnectionFactory.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<WarehouseStock>(sql, new { WarehouseId = w_id, ProductId = p_id });
        }

        public async Task<IEnumerable<WarehouseStock>> getWareHouseStockByWId(int id)
        {
            var sql = @"SELECT * FROM ""WarehouseStocks"" WHERE ""warehouse_id"" = @WarehouseId";
            using var connection = _readConnectionFactory.CreateConnection();
            return await connection.QueryAsync<WarehouseStock>(sql, new { WarehouseId = id });
        }
        public async Task update(int id)
        {
            var res = await unitOfWorks.WareHouseStockReadRepository.GetByIdAsync(id);
            if(res == null)
            {
                return;
            }
            res.status = "Approved";
            unitOfWorks.WareHouseStockWriteRepository.Update(res);
            unitOfWorks.Complete();
        }
    }
}
