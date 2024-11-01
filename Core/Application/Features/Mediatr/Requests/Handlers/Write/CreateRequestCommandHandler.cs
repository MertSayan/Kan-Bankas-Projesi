using Application.Constants;
using Application.Features.Mediatr.Requests.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Requests.Handlers.Write
{
    public class CreateRequestCommandHandler : IRequestHandler<CreateRequestCommand>
    {
        private readonly IRepository<Request> _repository;
        private readonly IRepository<BloodStock> _bloodStockRepository;

        public CreateRequestCommandHandler(IRepository<Request> repository, IRepository<BloodStock> bloodStockRepository)
        {
            _repository = repository;
            _bloodStockRepository = bloodStockRepository;
        }

        public async Task Handle(CreateRequestCommand request, CancellationToken cancellationToken)
        {
            Request istek = new Request();
            istek.Amount = request.Amount;
            istek.BloodTypeId = request.BloodTypeId;
            istek.UserId= request.UserId;
            await _repository.CreateAsync(istek);

            var value = await _bloodStockRepository.GetByFilterAsync(x => x.BloodTypeId == istek.BloodTypeId);
            if (value != null)
            {
                var mevcutKan = value.Amount;
                var istenenKan = istek.Amount;
                if (istenenKan <= mevcutKan)
                {
                    value.Amount -= istenenKan;
                    await _bloodStockRepository.UpdateAsync(value);
                }
                else
                {
                    throw new Exception("Depoda bu kadar kan yok");
                }
            }
            else
            {
                throw new Exception(Messages<BloodStock>.EntityNotFound);
            }

        }
    }
}
