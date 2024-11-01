using Application.Features.Mediatr.Users.Queries;
using Application.Features.Mediatr.Users.Results;
using Application.Interfaces;
using Application.Interfaces.UserInterface;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Users.Handlers.Read
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, List<GetAllUserQueryResult>>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public GetAllUserQueryHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAllUserQueryResult>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllUserWithRoleAndBloodTypeName();
            var result=_mapper.Map<List<GetAllUserQueryResult>>(values);
            return result;
        }
    }
}
