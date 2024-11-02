using Application.Constants;
using Application.Features.Mediatr.Users.Commands;
using Application.Features.Mediatr.Users.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserList()
        {
            var values = await _mediator.Send(new GetAllUserQuery());
            return Ok(values);
        }
        [HttpGet("email,password")]
        public async Task<IActionResult> GetUserByEmailAndPassword(string Email, string Password)
        {
            var values = await _mediator.Send(new GetUserByMailAndPasswordQuery(Email,Password));
            return Ok(values);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var values = await _mediator.Send(new GetUserByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<User>.EntityAdded);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<User>.EntityUpdated);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveUser(int id)
        {
            await _mediator.Send(new RemoveUsercommand(id));
            return Ok(Messages<User>.EntityDeleted);
        }
    }
}
