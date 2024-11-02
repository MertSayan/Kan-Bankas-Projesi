using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.RegisterDtos
{
    public class CreateRegisterDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int BloodTypeId { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageUrl { get; set; }
    }
}
