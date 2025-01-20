using KovserHedieyyeler.Application.DTOs.Positions;
using KovserHedieyyeler.Application.Features.Commands.Positions.Create;
using KovserHedieyyeler.Application.Features.Commands.Positions.Delete.Permanently;
using KovserHedieyyeler.Application.Features.Commands.Positions.Delete.Temporarily;
using KovserHedieyyeler.Application.Features.Commands.Positions.Update.Update;
using KovserHedieyyeler.Application.Features.Queries.Positions.GetAll;
using KovserHedieyyeler.Application.Features.Queries.Positions.GetSingle;
using KovserHediyyeler.Application.Features.Commands.Positions.Update.Recover;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kovser.Hediyyeler.App.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        readonly IMediator _mediator;

        public PositionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] GetAllPositionsQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Datas);
        }

        //[AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Create Position", Menu = AuthorizeDefinitionConstants.Positions)]
        [HttpPost]
        public async Task<IActionResult> CreateAsync(PositionCommandDto dto)
        {
            var request = new CreatePositionCommandRequest
            {
                Dto = dto
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var request = new GetSinglePositionQueryRequest
            {
                Id = Guid.Parse(id)
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Dto);
        }

        //[AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "Delete Temporarily Position", Menu = AuthorizeDefinitionConstants.Positions)]
        [HttpDelete("DeleteTemporarily/{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var request = new DeleteTemporarilyPositionCommandRequest
            {
                Id = Guid.Parse(id)
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        // [AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "Remove Permanently Position", Menu = AuthorizeDefinitionConstants.Positions)]
        [HttpDelete("RemovePermanently/{id}")]
        public async Task<IActionResult> RemoveAsync(string id)
        {
            var request = new RemovePermanentlyPositionCommandRequest
            {
                Id = Guid.Parse(id)
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        // [AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Update Total Position", Menu = AuthorizeDefinitionConstants.Positions)]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdatePositionCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        // [AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Recover Deleted Position", Menu = AuthorizeDefinitionConstants.Positions)]
        [HttpPatch("RecoverData/{id}")]
        public async Task<IActionResult> RecoverDataAsync(string id)
        {
            var request = new RecoverPositionCommandRequest
            {
                Id = Guid.Parse(id)
            }
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

    }
}
