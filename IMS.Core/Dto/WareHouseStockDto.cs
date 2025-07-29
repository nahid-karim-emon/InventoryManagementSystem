using IMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Dto
{
    public class WareHouseStockInfoDto
    {
        public int warehouse_id { get; set; }
        public int purchage_order_id { get; set; }
        public int product_id { get; set; }
        public int quantity { get; set; }
    }
}
