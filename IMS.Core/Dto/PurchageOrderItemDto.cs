using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Dto
{
    public class PurchageOrderItemDto
    {
        public int purchage_order_id { get; set; }
        public int product_id { get; set; }
        public int quantity { get; set; }
    }
}
