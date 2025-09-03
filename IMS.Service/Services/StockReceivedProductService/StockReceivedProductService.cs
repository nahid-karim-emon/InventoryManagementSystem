using Dapper;
using IMS.Core.Dto;
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
        public async Task<IEnumerable<WarehouseProductSummaryDto>> GetProducts(IEnumerable<int> stockIds)
        {
            var sql = @"SELECT
                    wrp.product_id,
                    SUM(wrp.good_product) AS total_good_product,
                    SUM(wrp.damaged_product) AS total_damaged_product
                FROM
                    public.""WarehouseReceivedProducts"" wrp
                WHERE
                    wrp.warehouse_stock_id = ANY(@StockIds)
                    AND wrp.""isDelete"" = false
                GROUP BY
                    wrp.product_id";
            using var connection = _readConnectionFactory.CreateConnection();
            return await connection.QueryAsync<WarehouseProductSummaryDto>(sql, new { StockIds = stockIds.ToList() });
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
