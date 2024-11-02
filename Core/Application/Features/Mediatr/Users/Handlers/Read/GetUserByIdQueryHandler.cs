using Application.Features.Mediatr.Users.Queries;
using Application.Features.Mediatr.Users.Results;
using Application.Interfaces.UserInterface;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Users.Handlers.Read
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdQueryResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetUserByIdQueryResult> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var value = new GetUserByIdQueryResult();
            var user = await _userRepository.GetUserByIdWithRoleAndBloodTypeName(request.Id);
            if (user != null)
            {
                value = _mapper.Map<GetUserByIdQueryResult>(user);
                value.IsExist = true;

                return value;
            }
            else
            {
                value.IsExist = false;
            }
            return null;
        }
    }
}
