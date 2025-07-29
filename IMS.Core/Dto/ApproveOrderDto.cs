using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Dto
{
    public class ApproveOrderDto
    {
        public int purchase_order_id { get; set; }
        public string warehouse {  get; set; }
    }
}
