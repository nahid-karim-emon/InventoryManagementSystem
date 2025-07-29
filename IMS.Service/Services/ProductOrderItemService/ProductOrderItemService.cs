using Dapper;
using IMS.Core.Entities;
using IMS.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.Services.ProductOrderItemService
{
    public class ProductOrderItemService(IReadDbConnectionFactory _readConnectionFactory, IWriteDbConnectionFactory _writeConnectionFactory, IUnitOfWorks _unitOfWorks) : IProductOrderItemService
    {
        public async Task<IEnumerable<PurchaseOrderItem>> getAllPurchaseOrderItem()
        {
            var sql = @"SELECT * FROM ""PurchaseOrdersItem""";
            using var connection = _readConnectionFactory.CreateConnection();
            return await connection.QueryAsync<PurchaseOrderItem>(sql);
        }
        public async Task<IEnumerable<PurchaseOrderItem>> getPurchaseOrderItemByPOId(int purchaseOrderId)
        {
            var sql = @"SELECT * FROM ""PurchaseOrdersItem"" WHERE ""purchage_order_id"" = @PurchaseOrderId";
            using var connection = _readConnectionFactory.CreateConnection();
            return await connection.QueryAsync<PurchaseOrderItem>(sql, new { PurchaseOrderId = purchaseOrderId });
        }

        public async Task update(int pO_id, int p_id, int quantity)
        {
            var sql = @"
            UPDATE ""PurchaseOrdersItem""
            SET ""quantity"" = @Quantity
            WHERE ""purchage_order_id"" = @PurchaseOrderId AND ""product_id"" = @ProductId";

            using var connection = _writeConnectionFactory.CreateConnection();
            await connection.ExecuteAsync(sql, new
            {
                Quantity = quantity,
                PurchaseOrderId = pO_id,
                ProductId = p_id
            });
        }
        public async Task addPurchaseOrderItem(PurchaseOrderItem purchaseOrderItem)
        {
            await _unitOfWorks.PurchageOrderItemWriteRepository.AddAsync(purchaseOrderItem);
            _unitOfWorks.Complete();
        }
    }
}
