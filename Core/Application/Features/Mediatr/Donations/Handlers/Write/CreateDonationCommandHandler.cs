using Application.Constants;
using Application.Features.Mediatr.Donations.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Donations.Handlers.Write
{
    public class CreateDonationCommandHandler : IRequestHandler<CreateDonationCommand>
    {
        private readonly IRepository<Donation> _repository;
        private readonly IRepository<BloodStock> _bloodStockRepository;

        public CreateDonationCommandHandler(IRepository<Donation> repository, IRepository<BloodStock> bloodStockRepository)
        {
            _repository = repository;
            _bloodStockRepository = bloodStockRepository;
        }

        public async Task Handle(CreateDonationCommand request, CancellationToken cancellationToken)
        {
            Donation donation = new Donation();
            donation.Amount= request.Amount;
            donation.BloodTypeId= request.BloodTypeId;
            donation.UserId= request.UserId;
            await _repository.CreateAsync(donation);

            var value=await _bloodStockRepository.GetByFilterAsync(x=>x.BloodTypeId==request.BloodTypeId);
            if (value!=null)
            {
                value.Amount += request.Amount;
                await _bloodStockRepository.UpdateAsync(value);
            }
            else
            {
                throw new Exception(Messages<BloodStock>.EntityNotFound);
            }


        }
    }
}
