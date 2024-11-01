using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.BloodTypes.Commands
{
    public class RemoveBloodTypeCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveBloodTypeCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
