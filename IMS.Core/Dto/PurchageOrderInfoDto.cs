using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Dto
{
    public class PurchageOrderInfoDto
    {
        public int PurchaseOrderId { get; set; }
        public string Status { get; set; }
        public decimal TotalCost { get; set; }
        public int TotalItems { get; set; }
    }
}
