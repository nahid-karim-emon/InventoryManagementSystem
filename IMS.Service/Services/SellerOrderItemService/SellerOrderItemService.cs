using Dapper;
using IMS.Core.Entities;
using IMS.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.Services.SellerOrderItemService
{
    public class SellerOrderItemService(IUnitOfWorks unitOfWorks, IReadDbConnectionFactory _readConnectionFactory) : ISellerOrderItemService
    {
        public async Task addSellerOrderItem(SellerOrderItem orderItem)
        {
            await unitOfWorks.SellerOrderItemWriteRepository.AddAsync(orderItem);
            unitOfWorks.Complete();
        }

        public async Task<IEnumerable<SellerOrderItem>> getAllOrder(int id)
        {
            var sql = @"SELECT * FROM ""SellerOrderItems"" WHERE ""seller_order_id"" = @Id";
            using var connection = _readConnectionFactory.CreateConnection();
            return await connection.QueryAsync<SellerOrderItem>(sql, new { Id = id });
        }

        public async Task<int> GetTotalProductSalesByWarehouse(int warehouseId, int productId)
        {
            var sql = @"
                SELECT
                    COALESCE(SUM(soi.quantity), 0)
                FROM
                    public.""SellerOrderItems"" AS soi
                INNER JOIN
                    public.""SellerOrders"" AS so ON soi.seller_order_id = so.id
                WHERE
                    so.warehouse_id = @WarehouseId
                    AND soi.product_id = @ProductId
                    AND so.""isDelete"" = false
                    AND soi.""isDelete"" = false
                    AND so.status = 'Done';
            ";

            using var connection = _readConnectionFactory.CreateConnection();
            var totalSold = await connection.ExecuteScalarAsync<int>(sql, new { WarehouseId = warehouseId, ProductId = productId });
            return totalSold;
        }
    }
}
