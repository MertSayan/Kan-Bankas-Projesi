using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.BloodTypes.Commands
{
    public class UpdateBloodTypeCommand:IRequest
    {
        public int BloodTypeId { get; set; }
        public string BloodName { get; set; }
    }
}
