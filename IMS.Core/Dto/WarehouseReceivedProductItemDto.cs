using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Dto
{
    public class WarehouseReceivedProductItemDto
    {
        public string product {  get; set; }
        public int good_product { get; set; }
        public int damaged_product { get; set; }
        public int currentInStock { get; set; }
    }
}
