using KovserHedieyyeler.Application.Features.Commands.Shops.Create.CreateShop;
using KovserHedieyyeler.Application.Features.Commands.Shops.Create.CreateShopAddress;
using KovserHedieyyeler.Application.Features.Commands.Shops.Delete.Permanently.RemoveShop;
using KovserHedieyyeler.Application.Features.Commands.Shops.Delete.Permanently.RemoveShopAddress;
using KovserHedieyyeler.Application.Features.Commands.Shops.Delete.Temporarily;
using KovserHedieyyeler.Application.Features.Commands.Shops.Update.UpdateShop.Update;
using KovserHedieyyeler.Application.Features.Commands.Shops.Update.UpdateShop.UpdateTotal;
using KovserHedieyyeler.Application.Features.Commands.Shops.Update.UpdateShopAddress;
using KovserHedieyyeler.Application.Features.Queries.Shops.GetAll.GetAllShopAddresses;
using KovserHedieyyeler.Application.Features.Queries.Shops.GetAll.GetAllShops;
using KovserHedieyyeler.Application.Features.Queries.Shops.GetSingle;
using KovserHediyyeler.Application.Features.Commands.Shops.Update.Recover;
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

        // [AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Create Shop", Menu = AuthorizeDefinitionConstants.Shops)]
        [HttpPost("CreateShop")]
        public async Task<IActionResult> CreateShopAsync([FromForm] CreateShopCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        // [AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Add Shop's Address", Menu = AuthorizeDefinitionConstants.Shops)]
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
                Id = Guid.Parse(id)
            };

            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Dto);
        }

        //[AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "Delete Temporarily Shop", Menu = AuthorizeDefinitionConstants.Shops)]
        [HttpDelete("DeleteTemporarily/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] string id)
        {
            var request = new DeleteTemporarilyShopCommandRequest
            {
                Id = Guid.Parse(id)
            };

            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        // [AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "Remove Permanently Shop", Menu = AuthorizeDefinitionConstants.Shops)]
        [HttpDelete("RemovePermanentlyShop/{id}")]
        public async Task<IActionResult> RemoveShopAsync([FromRoute] string id)
        {
            var request = new RemovePermanentlyShopCommandRequest
            {
                Id = Guid.Parse(id)
            };

            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        // [AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "Remove Permanently Shop's Address", Menu = AuthorizeDefinitionConstants.Shops)]
        [HttpDelete("RemovePermanentlyShopAddress/{id}")]
        public async Task<IActionResult> RemoveShopAddressAsync([FromRoute] string id)
        {
            var request = new RemoveShopAddressCommandRequest
            {
                Id = Guid.Parse(id),
            };

            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        // [AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Recover Deleted Shop", Menu = AuthorizeDefinitionConstants.Shops)]
        [HttpPatch("RecoverData/{id}")]
        public async Task<IActionResult> RecoverDataAsync([FromRoute] string id)
        {
            var request = new RecoverShopCommandRequest
            {
                Id = Guid.Parse(id)
            };

            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        // [AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Update Total Shop", Menu = AuthorizeDefinitionConstants.Shops)]
        [HttpPut("UpdateTotalShop")]
        public async Task<IActionResult> UpdateTotalShopAsync([FromForm] UpdateTotalShopCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        // [AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Update Shop", Menu = AuthorizeDefinitionConstants.Shops)]
        [HttpPatch("UpdateShop")]
        public async Task<IActionResult> UpdateShopAsync([FromForm] UpdateShopCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        //[AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Update Shop's Address", Menu = AuthorizeDefinitionConstants.Shops)]
        [HttpPatch("UpdateShopAddress")]
        public async Task<IActionResult> UpdateShopAddressAsync([FromForm] UpdateShopAddressCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
