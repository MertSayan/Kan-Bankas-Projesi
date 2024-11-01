using Application.Constants;
using Application.Features.Mediatr.Donations.Commands;
using Application.Features.Mediatr.Donations.Queries;
using Application.Features.Mediatr.Requests.Commands;
using Application.Features.Mediatr.Requests.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRequest()
        {
            var value = await _mediator.Send(new GetAllRequestQuery());
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRequest(CreateRequestCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Request>.EntityAdded);
        }
    }
}
