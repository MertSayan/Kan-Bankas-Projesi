using Application.Features.Mediatr.Users.Queries;
using Application.Features.Mediatr.Users.Results;
using Application.Interfaces.UserInterface;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Users.Handlers.Read
{
    public class GetUserByIdWithRoleAndBloodTypeNameAndDonationAndRequestCountQueryHandler : IRequestHandler<GetUserByIdWithRoleAndBloodTypeNameAndDonationAndRequestCountQuery, GetUserByIdWithRoleAndBloodTypeNameAndDonationAndRequestCountQueryResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdWithRoleAndBloodTypeNameAndDonationAndRequestCountQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetUserByIdWithRoleAndBloodTypeNameAndDonationAndRequestCountQueryResult> Handle(GetUserByIdWithRoleAndBloodTypeNameAndDonationAndRequestCountQuery request, CancellationToken cancellationToken)
        {
            var value = await _userRepository.GetUserByIdWithRoleAndBloodTypeNameAndDonationAndRequestCount(request.Id);
            if (value != null)
            {
                var result=_mapper.Map<GetUserByIdWithRoleAndBloodTypeNameAndDonationAndRequestCountQueryResult>(value);
                result.IsExist = true;
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
