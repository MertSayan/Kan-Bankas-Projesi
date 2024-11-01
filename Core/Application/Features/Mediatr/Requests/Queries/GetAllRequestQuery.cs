using Application.Features.Mediatr.Requests.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Requests.Queries
{
    public class GetAllRequestQuery:IRequest<List<GetAllRequestQueryResult>>
    {
    }
}
