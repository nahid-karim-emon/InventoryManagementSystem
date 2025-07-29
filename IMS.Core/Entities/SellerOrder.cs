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
    public class SellerOrder : ISoftDeletable, IEntityWithName
    {
        [Key]
        public int id { get; set; }
        public int customer_id { get; set; }
        [ForeignKey(nameof(customer_id))]
        public Customer Customer { get; set; }
        public int warehouse_id { get; set; }
        [ForeignKey(nameof(warehouse_id))]
        public Warehouse Warehouse { get; set; }
        public DateTime? created { get; set; }
        public string status { get; set; } = "Approved";
        public bool isDelete { get; set; } = false;
        public string name { get; set; }
    }
}
