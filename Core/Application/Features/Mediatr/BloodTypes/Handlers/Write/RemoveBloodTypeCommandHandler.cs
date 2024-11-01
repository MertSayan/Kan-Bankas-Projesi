using Application.Features.Mediatr.BloodTypes.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.BloodTypes.Handlers.Write
{
    public class RemoveBloodTypeCommandHandler : IRequestHandler<RemoveBloodTypeCommand>
    {
        private readonly IRepository<BloodType> _repositories;

        public RemoveBloodTypeCommandHandler(IRepository<BloodType> repositories)
        {
            _repositories = repositories;
        }

        public async Task Handle(RemoveBloodTypeCommand request, CancellationToken cancellationToken)
        {
            var value=await _repositories.GetByIdAsync(request.Id);
            if(value != null)
            {
                await _repositories.RemoveAsync(value);
            }
        }
    }
}
