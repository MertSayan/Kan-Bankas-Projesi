using Application.Constants;
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
    public class UpdateBloodTypeCommandHandler : IRequestHandler<UpdateBloodTypeCommand>
    {
        private readonly IRepository<BloodType> _repository;

        public UpdateBloodTypeCommandHandler(IRepository<BloodType> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBloodTypeCommand request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.BloodTypeId);
            if (value != null)
            {
                value.BloodName = request.BloodName;
                await _repository.UpdateAsync(value);
            }
            else
            {
                throw new Exception(Messages<BloodType>.EntityNotFound);
            }
        }
    }
}
