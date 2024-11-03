using Application.Constants;
using Application.Features.Mediatr.Abouts.Commands;
using Application.Features.Mediatr.Abouts.Queries;
using Application.Features.Mediatr.Abouts.Commands;
using Application.Features.Mediatr.Abouts.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AboutController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAbout()
        {
            var values = await _mediator.Send(new GetAboutUsQuery());
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<About>.EntityAdded);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<About>.EntityUpdated);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAbout(int id)
        {
            await _mediator.Send(new RemoveAboutCommand(id));
            return Ok(Messages<About>.EntityDeleted);
        }
    }
}
