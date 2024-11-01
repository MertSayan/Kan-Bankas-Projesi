using Application.Features.Mediatr.BloodStocks.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodStocksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BloodStocksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBloodStocks()
        {
            var value = await _mediator.Send(new GetAllBloodStockQuery());
            return Ok(value);
        }
    }
}
