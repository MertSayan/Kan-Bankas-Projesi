using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Donations.Results
{
    public class GetAllDonationQueryResult
    {
        public int DonationId { get; set; }
        public string UserName { get; set; }
        public string BloodTypeName { get; set; }
        public int Amount { get; set; }
        public DateTime? BağışTarihi { get; set; }
    }
}
