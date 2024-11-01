using Application.Features.Mediatr.Requests.Queries;
using Application.Features.Mediatr.Requests.Results;
using Application.Interfaces.RequestInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Requests.Handlers.Read
{
    public class GetAllRequestQueryHandler : IRequestHandler<GetAllRequestQuery, List<GetAllRequestQueryResult>>
    {
        private readonly IRequestRepository _repository;

        public GetAllRequestQueryHandler(IRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllRequestQueryResult>> Handle(GetAllRequestQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllRequestWithUserNameAndBloodTypeName();
            return values.Select(x => new GetAllRequestQueryResult
            {
                RequestId = x.RequestId,
                BloodTypeName = x.BloodType.BloodName,
                UserName = x.User.Name +" "+x.User.Surname,
                Amount = x.Amount,
                IstekTarihi=x.CreatedDate
            }).ToList();
        }
    }
}
