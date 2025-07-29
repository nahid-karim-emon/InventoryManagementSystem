using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Dto
{
    public class SellerOrderInfoDto
    {
        public string CustomerName { get; set; }
        public string WareHouseName { get; set; }
        public List<ProductOrderItemDto> Products { get; set; }
        public int TotalProducts { get; set; }
        public int TotalCost { get; set; }
    }
}
