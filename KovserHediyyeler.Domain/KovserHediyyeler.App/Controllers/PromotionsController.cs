using KovserHedieyyeler.Application.Features.Queries.Promotions.GetAll;
using KovserHedieyyeler.Application.Features.Queries.Promotions.GetSingle;
using KovserHediyyeler.Application.Features.Commands.Promotions.Create;
using KovserHediyyeler.Application.Features.Commands.Promotions.Delete;
using KovserHediyyeler.Application.Features.Commands.Promotions.Update;
using KovserHediyyeler.Application.Features.Queries.Promotions.GetExpireDate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KovserHediyyeler.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionsController : ControllerBase
    {
        readonly IMediator _mediator;

        public PromotionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] GetAllPromotionsQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Datas);
        }

        [HttpPost("CreatePromotion")]
        public async Task<IActionResult> CreateAsync([FromForm] CreatePromotionCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var request = new GetSinglePromotionQueryRequest
            {
                Id = Guid.Parse(id)
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Dto);
        }

        [HttpGet("PromotionExpireDate{id}")]
        public async Task<IActionResult> GetPromotionExpireDateAsync(string id)
        {
            var request = new GetPromotionExpireDateQueryRequest
            {
                Id = Guid.Parse(id)
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.ExpireDate);
        }

        [HttpDelete("RemovePermanentlyPromotion")]
        public async Task<IActionResult> RemoveAsync(RemovePromotionCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPatch("UpdatePromotion")]
        public async Task<IActionResult> UpdateAsync([FromForm] UpdatePromotionCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
