using KovserHedieyyeler.Application.Features.Commands.Baskets.AddItemToBasket;
using KovserHedieyyeler.Application.Features.Commands.Baskets.ClearBasket;
using KovserHedieyyeler.Application.Features.Commands.Baskets.RemoveItemFromBasket;
using KovserHedieyyeler.Application.Features.Commands.Baskets.RemoveItemFromBasketAddToWishList;
using KovserHedieyyeler.Application.Features.Commands.Baskets.UpdateProductCount;
using KovserHedieyyeler.Application.Features.Queries.Baskets.Get.GetBasket;
using KovserHedieyyeler.Application.Features.Queries.Baskets.Get.GetBasketCount;
using KovserHedieyyeler.Application.Features.Queries.Baskets.Get.GetBasketTotalPrice;
using MediatR;
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

        [HttpGet("GetBasket")]
        public async Task<IActionResult> GetBasketAsync(string CustomerId)
        {
            var request = new GetBasketQueryRequest { CustomerId = CustomerId };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Dto);
        }

        [HttpGet("GetBasketCount")]
        public async Task<IActionResult> GetBasketCountAsync(string CustomerId)
        {
            var request = new GetBasketCountQueryRequest { CustomerId = CustomerId };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Count);
        }

        [HttpGet("GetBasketTotalPrice")]
        public async Task<IActionResult> GetBasketTotalPriceAsync(string CustomerId)
        {
            var request = new GetBasketTotalPriceQueryRequest { CustomerId = CustomerId };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.TotalPrice);
        }

        [HttpPost("AddItemToBasket")]
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

        [HttpPatch("UpdateProductCount")]
        public async Task<IActionResult> UpdateProductCountAsync(UpdateProductCountCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
