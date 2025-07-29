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
    public class Product : ISoftDeletable, IEntityWithName
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string description { get; set; }
        public int category_id { get; set; }
        [ForeignKey(nameof(category_id))]
        public ProductCategory ProductCategory { get; set; }
        public int brand_id { get; set; }
        [ForeignKey(nameof(brand_id))]
        public Brand Brand { get; set; }
        [Required]
        public int unit_cost { get; set; }
        public bool isDelete { get; set; } = false;
    }
}
