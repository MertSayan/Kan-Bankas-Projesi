using Application.Features.Mediatr.Roles.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Roles.Handlers.Write
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand>
    {
        private readonly IRepository<Role> _repository;

        public CreateRoleCommandHandler(IRepository<Role> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Role
            {
                RoleName = request.RoleName,
            });
        }
    }
}
