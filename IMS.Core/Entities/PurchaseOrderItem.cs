using IMS.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Entities
{
    public class PurchaseOrderItem : ISoftDeletable,IEntityWithName
    {
        [Key]
        public int Id { get; set; }
        public int purchage_order_id { get; set; }
        [ForeignKey(nameof(purchage_order_id))]
        public PurchageOrder PurchageOrder { get; set; }
        public int product_id { get; set; }
        [ForeignKey(nameof(product_id))]
        public Product Product { get; set; }
        public int quantity { get; set; }
        public bool isDelete { get; set; } = false;
        public string ?name {  get; set; }
    }
}
