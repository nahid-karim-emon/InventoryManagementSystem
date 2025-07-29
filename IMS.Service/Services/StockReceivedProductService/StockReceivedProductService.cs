using Dapper;
using IMS.Core.Entities;
using IMS.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.Services.StockReceivedProductService
{
    public class StockReceivedProductService(IReadDbConnectionFactory _readConnectionFactory) : IStockReceivedProductService
    {
        public async Task<IEnumerable<WarehouseReceivedProduct>> GetProducts(int id)
        {
            var sql = @"SELECT * FROM ""WarehouseReceivedProducts"" WHERE ""warehouse_stock_id"" = @Id";
            using var connection = _readConnectionFactory.CreateConnection();
            return await connection.QueryAsync<WarehouseReceivedProduct>(sql, new { Id = id });
        }

        public async Task<int> GetGoodProductCountByWarehouseAndProduct(int warehouseId, int productId)
        {
            var sql = @"
                SELECT 
                    COALESCE(SUM(wrp.good_product), 0)
                FROM 
                    public.""WarehouseReceivedProducts"" AS wrp
                INNER JOIN 
                    public.""WarehouseStocks"" AS ws ON wrp.warehouse_stock_id = ws.id
                WHERE 
                    ws.warehouse_id = @WarehouseId
                    AND wrp.product_id = @ProductId
                    AND ws.""isDelete"" = false
                    AND wrp.""isDelete"" = false;
            ";

            using var connection = _readConnectionFactory.CreateConnection();
            var totalGoodProducts = await connection.ExecuteScalarAsync<int>(sql, new { WarehouseId = warehouseId, ProductId = productId });

            return totalGoodProducts;
        }
    }
}
