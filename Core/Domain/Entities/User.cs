using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User: Entity
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int BloodTypeId { get; set; }
        public BloodType BloodType { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageUrl { get; set; }
        public List<Donation> Donations { get; set; }
        public List<Request> Requests { get; set; }
    }
}
