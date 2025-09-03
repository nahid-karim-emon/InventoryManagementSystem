using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Dto
{
    public class WarehouseProductSummaryDto
    {
        public int product_id { get; set; }
        public string name { get; set; }
        public int total_good_product { get; set; }
        public int total_damaged_product { get; set; }
    }
}
