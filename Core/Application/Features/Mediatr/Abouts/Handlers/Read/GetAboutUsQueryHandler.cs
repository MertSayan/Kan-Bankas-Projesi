using Application.Features.Mediatr.Abouts.Queries;
using Application.Features.Mediatr.Abouts.Results;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Abouts.Handlers.Read
{
    public class GetAboutUsQueryHandler : IRequestHandler<GetAboutUsQuery, List<GetAboutUsQueryResult>>
    {
        private readonly IRepository<About> _repository;
        private readonly IMapper _mapper;

        public GetAboutUsQueryHandler(IRepository<About> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAboutUsQueryResult>> Handle(GetAboutUsQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            var result= _mapper.Map<List<GetAboutUsQueryResult>>(values);
            return result;
        }
    }
}
