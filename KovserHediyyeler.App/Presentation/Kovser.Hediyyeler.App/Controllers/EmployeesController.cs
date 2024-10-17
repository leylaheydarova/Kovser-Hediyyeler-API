using KovserHedieyyeler.Application.DTOs.Employees;
using KovserHedieyyeler.Application.Exceptions.BadRequestExceptions;
using KovserHedieyyeler.Application.Features.Commands.Employees.Create;
using KovserHedieyyeler.Application.Features.Commands.Employees.Update;
using KovserHedieyyeler.Application.Features.Queries.Employees.GetAll;
using KovserHedieyyeler.Application.Features.Queries.Employees.GetSingle;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kovser.Hediyyeler.App.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var request = new GetAllEmployeesQueryRequest();
            if (request == null) throw new BadRequestException();
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Dtos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] EmployeeCommandDto dto)
        {
            var request = new CreateEmployeeCommandRequest
            {
                Dto = dto
            };

            if (request == null) throw new BadRequestException();

            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var request = new GetSingleEmployeeQueryRequest
            {
                Id = id
            };

            if (request == null) throw new BadRequestException();

            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Dto);
        }

        [HttpDelete("DeleteTemporarily")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var request = new UpdateEmployeeCommandRequest
            {
                Id = id
            };
            if (request == null) throw new BadRequestException();

            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpDelete("RemovePermanently")]
        public async Task<IActionResult> RemoveAsync(string id)
        {
            var request = new UpdateEmployeeCommandRequest
            {
                Id = id
            };
            if (request == null) throw new BadRequestException();

            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromForm] EmployeeCommandDto dto, string id)
        {
            var request = new UpdateEmployeeCommandRequest
            {
                Id = id,
                Dto = dto
            };
            if (request == null) throw new BadRequestException();

            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
