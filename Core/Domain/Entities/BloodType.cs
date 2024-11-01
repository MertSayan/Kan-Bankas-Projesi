using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BloodType:Entity
    {
        public int BloodTypeId { get; set; }
        public string BloodName { get; set; }
        public List<BloodStock> BloodStocks { get; set;}
        public List<User> Users { get; set; }
        public List<Request> Requests { get; set; }
        public List<Donation> Donations{ get; set; }
    }
}
