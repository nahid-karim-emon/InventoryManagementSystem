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
    public class PurchageOrder : ISoftDeletable, IEntityWithName
    {
        [Key]
        public int id { get; set; }
        public int supplier_id { get; set; }
        [ForeignKey(nameof(supplier_id))]
        public Supplier Supplier { get; set; }
        public DateTime? created { get; set; }
        public string status { get; set; } = "Pending";
        public bool isDelete { get; set; } = false;
        public string ?name { get; set; }
    }
}
