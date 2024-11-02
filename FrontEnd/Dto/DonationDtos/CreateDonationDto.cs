using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.DonationDtos
{
    public class CreateDonationDto
    {
        public string NameSurname { get; set; }
        public string BloodTypeName { get; set; }
        public int UserId { get; set; }
        public int BloodTypeId { get; set; }
        public int Amount { get; set; }
    }
}
