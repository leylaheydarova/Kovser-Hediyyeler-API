using KovserHediyyeler.Application.DTOs.WishLists;
using KovserHediyyeler.Application.Features.Commands.WishLists.Add;
using KovserHediyyeler.Application.Features.Commands.WishLists.Remove;
using KovserHediyyeler.Application.Features.Queries.WishLists;
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

        [HttpGet("get-wishList")]
        public async Task<IActionResult> GetWishListAsync(string customerId)
        {
            var request = new GetWishListQueryRequest
            {
                CustomerId = customerId
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Dto);
        }

        [HttpPost("add-item-to-wishList")]
        public async Task<IActionResult> AddItemToWishListAsync(string customerId, Guid productId)
        {
            var dto = new WishListCommandDto
            {
                CustomerId = customerId,
                ProductId = productId
            };
            var request = new AddItemToWihListCommandRequest
            {
                Dto = dto
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Dto);
        }

        [HttpDelete("remove-item-from-wishList")]
        public async Task<IActionResult> RemoveItemFromWishListAsync(string customerId, Guid productId)
        {
            var dto = new WishListCommandDto
            {
                CustomerId = customerId,
                ProductId = productId
            };
            var request = new RemoveItemCommandRequest
            {
                Dto = dto
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
