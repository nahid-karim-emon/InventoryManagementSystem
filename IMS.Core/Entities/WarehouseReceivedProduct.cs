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
    public class WarehouseReceivedProduct : ISoftDeletable, IEntityWithName
    {
        [Key]
        public int id { get; set; }
        public int warehouse_stock_id { get; set; }
        [ForeignKey(nameof(warehouse_stock_id))]
        public WarehouseStock WarehouseStock { get; set; }
        public int product_id { get; set; }
        [ForeignKey(nameof(product_id))]
        public Product Product { get; set; }
        public int good_product {  get; set; }
        public int damaged_product { get; set; }
        public int missing_product { get; set; }
        public bool isDelete { get; set; } = false;
        public string? name { get; set; }
    }
}
