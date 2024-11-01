using Application.Features.Mediatr.BloodTypes.Queries;
using Application.Features.Mediatr.BloodTypes.Results;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.BloodTypes.Handlers.Read
{
    public class GetAllBloodTypeQueryHandler : IRequestHandler<GetAllBloodTypeQuery, List<GetAllBloodTypeQueryResult>>
    {
        private readonly IRepository<BloodType> _repository;

        public GetAllBloodTypeQueryHandler(IRepository<BloodType> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllBloodTypeQueryResult>> Handle(GetAllBloodTypeQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=> new GetAllBloodTypeQueryResult
            {
                BloodTypeId = x.BloodTypeId,
                BloodName=x.BloodName,
            }).ToList();
        }
    }
}
