using Application.Features.Mediatr.Donations.Queries;
using Application.Features.Mediatr.Donations.Results;
using Application.Interfaces.DonationInterface;
using MediatR;

namespace Application.Features.Mediatr.Donations.Handlers.Read
{
    public class GetAllDonationQueryHandler : IRequestHandler<GetAllDonationQuery, List<GetAllDonationQueryResult>>
    {
        private readonly IDonationRepsitory _repository;

        public GetAllDonationQueryHandler(IDonationRepsitory repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllDonationQueryResult>> Handle(GetAllDonationQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllDonationWithUserNameAndBloodTypeName();
            return values.Select(x => new GetAllDonationQueryResult
            {
                DonationId=x.DonationId,
                UserName= x.User.Name + " " + x.User.Surname,
                BloodTypeName =x.BloodType.BloodName,
                Amount=x.Amount,
                BağışTarihi=x.CreatedDate
            }).ToList();
        }
    }
}
