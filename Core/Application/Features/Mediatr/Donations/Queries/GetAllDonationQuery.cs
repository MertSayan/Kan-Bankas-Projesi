using Application.Features.Mediatr.Donations.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Donations.Queries
{
    public class GetAllDonationQuery:IRequest<List<GetAllDonationQueryResult>>
    {
    }
}
