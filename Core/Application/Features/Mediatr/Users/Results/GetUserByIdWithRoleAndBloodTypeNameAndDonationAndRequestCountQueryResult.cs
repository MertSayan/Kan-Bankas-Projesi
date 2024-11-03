using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Users.Results
{
    public class GetUserByIdWithRoleAndBloodTypeNameAndDonationAndRequestCountQueryResult
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; }
        public bool IsExist { get; set; }
        public string BloodTypeName { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageUrl { get; set; }

        public int TotalDonationsAmount { get; set; }

        public int TotalRequestsAmount { get; set; }
    }
}
