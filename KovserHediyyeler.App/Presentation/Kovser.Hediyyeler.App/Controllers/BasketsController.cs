using KovserHedieyyeler.Application.Features.Commands.Baskets.AddItemToBasket;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kovser.Hediyyeler.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        readonly IMediator _mediator;

        public BasketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddItemToBasketAsync(AddItemToBasketCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
