using Application.Features.Mediatr.Roles.Queries;
using Application.Features.Mediatr.Roles.Results;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Roles.Handlers.Read
{
    public class GetAllRoleQueryHandler : IRequestHandler<GetAllRoleQuery, List<GetAllRoleQueryResult>>
    {
        private readonly IRepository<Role> _repository;

        public GetAllRoleQueryHandler(IRepository<Role> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllRoleQueryResult>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=> new GetAllRoleQueryResult
            {
                RoleId=x.RoleId,
                RoleName=x.RoleName,
            }).ToList();
        }
    }
}
