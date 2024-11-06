using KovserHedieyyeler.Application.Features.Commands.Baskets.AddItemToBasket;
using KovserHedieyyeler.Application.Features.Commands.Baskets.ClearBasket;
using KovserHedieyyeler.Application.Features.Commands.Baskets.RemoveItemFromBasket;
using KovserHedieyyeler.Application.Features.Commands.Baskets.RemoveItemFromBasketAddToWishList;
using KovserHedieyyeler.Application.Features.Commands.Employees.Delete.Permanently.RemoveEmployeeAddress;
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

        [HttpDelete("ClearBasket")]
        public async Task<IActionResult> ClearBasketAsync(string CustomerId)
        {
            var request = new ClearBasketCommandRequest { CustomerId = CustomerId };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpDelete("RemoveItemFromBasket")]
        public async Task<IActionResult> RemoveItemFromBasketAsync(RemoveItemFromBasketCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPost("RemoveItemFromBasketAndAddToWishList")]
        public async Task<IActionResult> RemoveItemFromBasketAddToWishListAsync(RemoveFromBasketAddWishListCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
