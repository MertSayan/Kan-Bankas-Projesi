using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.BloodStocks.Results
{
    public class GetAllBloodStockQueryResult
    {
        public int StockId { get; set; }
        public string BloodTypeName { get; set; }
        public int Amount { get; set; }
    }
}
