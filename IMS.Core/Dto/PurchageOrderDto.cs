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
    public class PurchageOrderDto
    {
        [Required]
        public string SupplierName { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "At least one product must be included in the purchase order.")]
        public List<ProductOrderItemDto> Products { get; set; }
    }
}
