using KovserHediyyeler.Application.DTOs.Baskets;
using KovserHediyyeler.Application.Features.Commands.Baskets.Add;
using KovserHediyyeler.Application.Features.Commands.Baskets.Remove.ClearBasket;
using KovserHediyyeler.Application.Features.Commands.Baskets.Remove.RemoveItem;
using KovserHediyyeler.Application.Features.Commands.Baskets.Update.UpdateIsSelected;
using KovserHediyyeler.Application.Features.Commands.Baskets.Update.UpdateItemCount;
using KovserHediyyeler.Application.Features.Queries.Baskets.GetBasket;
using KovserHediyyeler.Application.Features.Queries.Baskets.GetTotalCount;
using KovserHediyyeler.Application.Features.Queries.Baskets.GetTotalPrice;
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

        [HttpGet("get-basket")]
        public async Task<IActionResult> GetBasketAsync(string customerId)
        {
            var request = new GetBasketQueryRequest
            {
                Id = customerId
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Dto);
        }

        [HttpPost("add-item-to-basket")]
        public async Task<IActionResult> AddItemToBasketAsync(Guid productId, int count, string userId)
        {
            var dto = new BasketCommandDto
            {
                ProductId = productId,
                UserId = userId,
                Count = count
            };
            var request = new AddItemToBasketCommandRequest
            {
                Dto = dto
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

        [HttpDelete("clear-basket")]
        public async Task<IActionResult> ClearBasketAsync(string userId)
        {
            var request = new ClearBasketCommandRequest
            {
                CustomerId = userId
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPatch("update-item-count")]
        public async Task<IActionResult> UpdateItemCountAsync(Guid productId, int count, string userId)
        {
            var dto = new BasketCommandDto
            {
                ProductId = productId,
                UserId = userId,
                Count = count
            };
            var request = new UpdateItemCountCommandRequest
            {
                Dto = dto
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpGet("get-total-price")]
        public async Task<IActionResult> GetTotalPriceAsync(string customerId)
        {
            var request = new GetTotalPriceQueryRequest
            {
                Id = customerId
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.TotalPrice);
        }

        [HttpGet("get-total-count")]
        public async Task<IActionResult> GetTotalCountAsync(string customerId)
        {
            var request = new GetTotalCountQueryRequest
            {
                Id = customerId
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.TotalCount);
        }
        [HttpPatch("set-isSelected-true")]
        public async Task<IActionResult> SetIsSelectedTrueAsync(SetIsSelectedTrueCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }
    }

}
