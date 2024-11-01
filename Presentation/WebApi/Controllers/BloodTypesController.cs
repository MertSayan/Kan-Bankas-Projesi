using Application.Constants;
using Application.Features.Mediatr.BloodTypes.Commands;
using Application.Features.Mediatr.BloodTypes.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BloodTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetBloodTypeList()
        {
            var values = await _mediator.Send(new GetAllBloodTypeQuery());
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBloodType(CreateBloodTypeCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<BloodType>.EntityAdded);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBloodType(UpdateBloodTypeCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<BloodType>.EntityUpdated);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveBloodType(int id)
        {
            await _mediator.Send(new RemoveBloodTypeCommand(id));
            return Ok(Messages<BloodType>.EntityDeleted);
        }
    }
}
