using KovserHediyyeler.Application.Features.Commands.WishLists.Add;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KovserHediyyeler.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListsController : ControllerBase
    {
        readonly IMediator _mediator;

        public WishListsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add-item-to-wishList")]
        public async Task<IActionResult> AddItemToWishListAsync(string customerId, Guid productId)
        {
            var request = new AddItemToWihListCommandRequest
            {
                CustomerId = customerId,
                ProductId = productId
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Dto);
        }
    }
}
