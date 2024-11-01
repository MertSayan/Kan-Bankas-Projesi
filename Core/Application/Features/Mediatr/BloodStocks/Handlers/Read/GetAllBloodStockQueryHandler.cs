using Application.Features.Mediatr.BloodStocks.Queries;
using Application.Features.Mediatr.BloodStocks.Results;
using Application.Interfaces;
using Application.Interfaces.BloodStockInterface;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.BloodStocks.Handlers.Read
{
    public class GetAllBloodStockQueryHandler : IRequestHandler<GetAllBloodStockQuery, List<GetAllBloodStockQueryResult>>
    {
        
        private readonly IBloodStockRepository _repository;

        public GetAllBloodStockQueryHandler(IBloodStockRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllBloodStockQueryResult>> Handle(GetAllBloodStockQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllBloodStockWithBloodName();
            return values.Select(x=> new GetAllBloodStockQueryResult
            {
                Amount = x.Amount,
                BloodTypeName = x.BloodType.BloodName,
                StockId=x.BloodStockId
            }).ToList();
        }
    }
}
