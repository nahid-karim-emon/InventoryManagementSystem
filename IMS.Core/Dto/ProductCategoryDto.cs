using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Dto
{
    public class ProductCategoryDto
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string description { get; set; }
    }
}
