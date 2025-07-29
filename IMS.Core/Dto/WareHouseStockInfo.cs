using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Dto
{
    public class WareHouseStockInfo
    {
        public string SupplierName { get; set; }
        public List<WarehouseReceivedProductItemDto> Products { get; set; }
    }
}
