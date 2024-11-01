using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Roles.Commands
{
    public class RemoveRoleCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveRoleCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
