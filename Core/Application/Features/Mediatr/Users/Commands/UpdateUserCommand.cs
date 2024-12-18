﻿using MediatR;

namespace Application.Features.Mediatr.Users.Commands
{
    public class UpdateUserCommand:IRequest
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int BloodTypeId { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageUrl { get; set; }
    }
}
