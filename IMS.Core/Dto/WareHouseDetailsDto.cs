using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Dto
{
    public class WareHouseDetailsDto
    {
        public string WareHouse {  get; set; }
        public List<WareHouseStockInfo> wareHouseStockInfos { get; set; }
    }
}
