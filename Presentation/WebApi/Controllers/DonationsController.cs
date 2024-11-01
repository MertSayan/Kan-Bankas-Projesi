using Application.Constants;
using Application.Features.Mediatr.Donations.Commands;
using Application.Features.Mediatr.Donations.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DonationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDonation()
        {
            var value=await _mediator.Send(new GetAllDonationQuery());  
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDonation(CreateDonationCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Donation>.EntityAdded);
        }

    }
}
