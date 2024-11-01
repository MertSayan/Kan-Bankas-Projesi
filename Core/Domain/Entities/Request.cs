using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Request: Entity
    {
        public int RequestId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int BloodTypeId { get; set; }
        public BloodType BloodType { get; set; }
        public int Amount { get; set; }
    }
}
