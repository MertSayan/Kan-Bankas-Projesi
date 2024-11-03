using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.AdminUser
{
    public class GetAllUserDto
    {
            public int UserId { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string RoleName { get; set; }
            public string BloodTypeName { get; set; }
            public string PhoneNumber { get; set; }
            public string ImageUrl { get; set; }
    }
}
