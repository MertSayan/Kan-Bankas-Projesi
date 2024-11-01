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
    public class CreateBloodTypeCommandHandler : IRequestHandler<CreateBloodTypeCommand>
    {
        private readonly IRepository<BloodType> _repository;

        public CreateBloodTypeCommandHandler(IRepository<BloodType> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBloodTypeCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new BloodType
            {
                BloodName = request.BloodName
            });
        }
    }
}
