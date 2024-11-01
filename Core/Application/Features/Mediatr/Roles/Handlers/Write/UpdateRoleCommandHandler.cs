using Application.Constants;
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
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand>
    {
        private readonly IRepository<Role> _repository;

        public UpdateRoleCommandHandler(IRepository<Role> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.RoleId);
            if (value != null)
            {
                value.RoleName = request.RoleName;
                await _repository.UpdateAsync(value);
            }
            else
            {
                throw new Exception(Messages<Role>.EntityNotFound);
            }
        }
    }
}
