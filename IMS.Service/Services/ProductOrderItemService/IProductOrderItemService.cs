using IMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.Services.ProductOrderItemService
{
    public interface IProductOrderItemService
    {
        Task<IEnumerable<PurchaseOrderItem>> getAllPurchaseOrderItem();
        Task<IEnumerable<PurchaseOrderItem>> getPurchaseOrderItemByPOId(int purchaseOrderId);
        Task update(int pO_id, int p_id, int quantity);
        Task addPurchaseOrderItem(PurchaseOrderItem purchaseOrderItem);
    }
}
