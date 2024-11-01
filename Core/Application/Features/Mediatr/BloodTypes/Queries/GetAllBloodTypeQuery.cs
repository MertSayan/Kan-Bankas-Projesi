using Application.Features.Mediatr.BloodTypes.Results;
using MediatR;

namespace Application.Features.Mediatr.BloodTypes.Queries
{
    public class GetAllBloodTypeQuery:IRequest<List<GetAllBloodTypeQueryResult>>
    {
    }
}
