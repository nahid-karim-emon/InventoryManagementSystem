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
    public class WarehouseStock : ISoftDeletable, IEntityWithName
    {
        [Key]
        public int id { get; set; }
        public int warehouse_id { get; set; }
        [ForeignKey(nameof(warehouse_id))]
        public Warehouse Warehouse { get; set; }
        public int purchage_order_id { get; set; }
        [ForeignKey(nameof(purchage_order_id))]
        public PurchageOrder PurchageOrder { get; set; }
        public DateTime createdAt { get; set; }

        public string status { get; set; } = "Pending";
        public bool isDelete { get; set; } = false;
        public string ?name { get; set; }
    }
}
