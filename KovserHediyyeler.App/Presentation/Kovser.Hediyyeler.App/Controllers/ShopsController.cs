using KovserHedieyyeler.Application.Features.Commands.Shops.Create.CreateShop;
using KovserHedieyyeler.Application.Features.Commands.Shops.Create.CreateShopAddress;
using KovserHedieyyeler.Application.Features.Commands.Shops.Delete.Permanently.RemoveShop;
using KovserHedieyyeler.Application.Features.Commands.Shops.Delete.Permanently.RemoveShopAddress;
using KovserHedieyyeler.Application.Features.Commands.Shops.Delete.Temporarily;
using KovserHedieyyeler.Application.Features.Commands.Shops.Recover;
using KovserHedieyyeler.Application.Features.Commands.Shops.Update.Shop;
using KovserHedieyyeler.Application.Features.Commands.Shops.Update.UpdateShopAddress;
using KovserHedieyyeler.Application.Features.Queries.Shops.GetAll.GetAllShopAddresses;
using KovserHedieyyeler.Application.Features.Queries.Shops.GetAll.GetAllShops;
using KovserHedieyyeler.Application.Features.Queries.Shops.GetSingle;
using MediatR;
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

        [HttpGet("GetAllShops")]
        public async Task<IActionResult> GetAllShopsAsync([FromQuery] GetAllShopsQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Datas);
        }

        [HttpGet("GetAllShopAddresses")]
        public async Task<IActionResult> GetAllShopAddressesAsync([FromQuery] GetAllShopAddressesQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Datas);
        }

        [HttpPost("CreateShop")]
        public async Task<IActionResult> CreateShopAsync([FromForm]CreateShopCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPost("CreateShopAddress")]
        public async Task<IActionResult> CreateShopAddressAsync([FromForm] CreateShopAddressCommandRequest request)
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

        [HttpDelete("RemovePermanentlyShop/{id}")]
        public async Task<IActionResult> RemoveShopAsync([FromRoute] string id)
        {
            var request = new RemovePermanentlyShopCommandRequest
            {
                Id = id
            };

            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpDelete("RemovePermanentlyShopAddress/{id}")]
        public async Task<IActionResult> RemoveShopAddressAsync([FromRoute] string id)
        {
            var request = new RemovePermanentlyShopAddressCommandRequest
            {
                Id = id,
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
