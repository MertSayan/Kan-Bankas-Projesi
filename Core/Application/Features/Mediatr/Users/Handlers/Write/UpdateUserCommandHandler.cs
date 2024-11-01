using Application.Constants;
using Application.Features.Mediatr.Users.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Users.Handlers.Write
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.UserId);
            if (value != null)
            {
                value=_mapper.Map(request, value);
                await _repository.UpdateAsync(value);
            }
            else
            {
                throw new Exception(Messages<User>.EntityNotFound);
            }
        }
    }
}
