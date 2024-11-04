using KovserHedieyyeler.Application.DTOs.Positions;
using KovserHedieyyeler.Application.Features.Commands.Positions.Create;
using KovserHedieyyeler.Application.Features.Commands.Positions.Delete.Permanently;
using KovserHedieyyeler.Application.Features.Commands.Positions.Delete.Temporarily;
using KovserHedieyyeler.Application.Features.Commands.Positions.Recover;
using KovserHedieyyeler.Application.Features.Commands.Positions.Update.Update;
using KovserHedieyyeler.Application.Features.Commands.Positions.Update.UpdateTotalPosition;
using KovserHedieyyeler.Application.Features.Queries.Positions.GetAll;
using KovserHedieyyeler.Application.Features.Queries.Positions.GetSingle;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

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
        public async Task<IActionResult> GetAllAsync([FromQuery]GetAllPositionsQueryRequest request) 
        { 
            var response =await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Datas);
        }

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
                Id = id
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Dto);
        }

        [HttpDelete("DeleteTemporarily/{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var request = new DeleteTemporarilyPositionCommandRequest
            {
                Id = id
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpDelete("RemovePermanently/{id}")]
        public async Task<IActionResult> RemoveAsync(string id)
        {
            var request = new RemovePermanentlyPositionCommandRequest
            {
                Id = id
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTotalAsync(UpdateTotalPositionCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPut("RecoverData/{id}")]
        public async Task<IActionResult> RecoverDataAsync(RecoverPositionCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateAsync(string id, PositionUpdateDto dto)
        {
            var request = new UpdatePositionCommandRequest
            {
                Id = id,
                Dto = dto
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
