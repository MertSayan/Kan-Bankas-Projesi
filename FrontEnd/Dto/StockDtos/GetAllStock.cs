using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.StockDtos
{
    public class GetAllStock
    {
        public int StockId { get; set; }
        public string BloodTypeName { get; set; }
        public string Amount { get; set; }
    }
}
