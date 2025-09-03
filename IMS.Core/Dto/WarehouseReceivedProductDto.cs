using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Dto
{
    public class WarehouseReceivedProductDto
    {
        public int warehouse_stock_id {  get; set; }
        public List<WarehouseReceivedProductItemsDto> warehouse_products { get; set; } = new();
    }
}
