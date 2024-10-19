using KovserHedieyyeler.Application.DTOs.Positions;
using KovserHedieyyeler.Application.Features.Commands.Positions.Create;
using KovserHedieyyeler.Application.Features.Commands.Positions.Delete.Permanently;
using KovserHedieyyeler.Application.Features.Commands.Positions.Delete.Temporarily;
using KovserHedieyyeler.Application.Features.Commands.Positions.Update;
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

        [HttpDelete("DeleteTemporarily")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var request = new DeleteTemporarilyPositionCommandRequest
            {
                Id = id
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpDelete("RemovePermanently")]
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
        public async Task<IActionResult> UpdateAsync(UpdatePositionCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
