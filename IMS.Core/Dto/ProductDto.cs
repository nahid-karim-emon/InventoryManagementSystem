using IMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Dto
{
    public class ProductDto
    {
        public string name { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public string category_name { get; set; }
        [Required]
        public string brand_name { get; set; }
        [Required]
        public int unit_cost { get; set; }
    }
}
