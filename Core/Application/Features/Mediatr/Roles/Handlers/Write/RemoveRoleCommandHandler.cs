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
    public class RemoveRoleCommandHandler : IRequestHandler<RemoveRoleCommand>
    {
        private readonly IRepository<Role> _repository;

        public RemoveRoleCommandHandler(IRepository<Role> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveRoleCommand request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.Id);
            if (value != null)
            {
                await _repository.RemoveAsync(value);
            }
            else
            {
                throw new Exception(Messages<Role>.EntityNotFound);
            }
        }
    }
}
