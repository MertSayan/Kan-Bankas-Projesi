using Application.Features.Mediatr.BloodStocks.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.BloodStocks.Queries
{
    public class GetAllBloodStockQuery:IRequest<List<GetAllBloodStockQueryResult>>
    {
    }
}
