﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Roles.Commands
{
    public class UpdateRoleCommand:IRequest
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
