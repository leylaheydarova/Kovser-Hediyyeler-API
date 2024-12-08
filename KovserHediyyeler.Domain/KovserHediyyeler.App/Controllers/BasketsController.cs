using KovserHediyyeler.Application.Features.Commands.Baskets.Add;
using KovserHediyyeler.Application.Features.Commands.Baskets.Remove.RemoveItem;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KovserHediyyeler.App.Controllers
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

        [HttpPost("add-item-to-basket")]
        public async Task<IActionResult> AddItemToBasketAsync(Guid productId, int count, string userId)
        {
            var request = new AddItemToBasketCommandRequest
            {
                ProductId = productId,
                Count = count,
                UserId = userId
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpDelete("remove-item-from-basket")]
        public async Task<IActionResult> RemoveItemFromBasketAsync(Guid productId, string userId)
        {
            var request = new RemoveItemFromBasketCommandRequest
            {
                ProductId = productId,
                CustomerId = userId
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
