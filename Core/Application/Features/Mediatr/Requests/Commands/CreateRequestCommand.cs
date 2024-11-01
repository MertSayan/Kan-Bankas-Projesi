using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Requests.Commands
{
    public class CreateRequestCommand:IRequest
    {
        public int UserId { get; set; }
        public int BloodTypeId { get; set; }
        public int Amount { get; set; }
    }
}
