using KovserHedieyyeler.Application.Features.Commands.Shops.Create;
using KovserHedieyyeler.Application.Features.Commands.Shops.Delete.Permanently;
using KovserHedieyyeler.Application.Features.Commands.Shops.Delete.Temporarily;
using KovserHedieyyeler.Application.Features.Commands.Shops.Recover;
using KovserHedieyyeler.Application.Features.Commands.Shops.Update.Shop;
using KovserHedieyyeler.Application.Features.Commands.Shops.Update.UpdateShopAddress;
using KovserHedieyyeler.Application.Features.Queries.Shops.GetAll;
using KovserHedieyyeler.Application.Features.Queries.Shops.GetSingle;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kovser.Hediyyeler.App.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        readonly IMediator _mediator;

        public ShopsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] GetAllShopsQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Datas);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm]CreateShopCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] string id)
        {
            var request = new GetSingleShopQueryRequest
            {
                Id = id
            };

            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Dto);
        }


        [HttpDelete("DeleteTemporarily/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] string id)
        {
            var request = new DeleteTemporarilyShopCommandRequest
            {
                Id = id
            };

            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpDelete("RemovePermanently/{id}")]
        public async Task<IActionResult> RemoveAsync([FromRoute] string id)
        {
            var request = new RemovePermanentlyShopCommandRequest
            {
                Id = id
            };

            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPut("RecoverData/{id}")]
        public async Task<IActionResult> RecoverDataAsync([FromRoute] string id)
        {
            var request = new RecoverShopCommandRequest
            {
                Id = id
            };

            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPut("UpdateShop")]
        public async Task<IActionResult> UpdateShopAsync([FromForm]UpdateShopCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPut("UpdateShopAddress")]
        public async Task<IActionResult> UpdateShopAddressAsync([FromForm] UpdateShopAddressCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
