using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Requests.Results
{
    public class GetAllRequestQueryResult
    {
        public int RequestId { get; set; }
        public string UserName { get; set; }
        public string BloodTypeName { get; set; }
        public int Amount { get; set; }
        public DateTime? IstekTarihi { get; set; }
    }
}
