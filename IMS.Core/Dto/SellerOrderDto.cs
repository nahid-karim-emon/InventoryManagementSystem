using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Dto
{
    public class SellerOrderDto
    {
        [Required]
        public string customer_name { get; set; }
        [Required]
        public string warehouse_name { get; set; }
        [Required]
        public List<ProductOrderItemsDto> Products { get; set; }
    }
}
