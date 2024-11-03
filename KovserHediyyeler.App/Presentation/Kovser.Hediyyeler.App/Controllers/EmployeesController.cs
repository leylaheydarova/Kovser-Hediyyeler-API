using KovserHedieyyeler.Application.Features.Commands.Employees.Create.CreateEmployee;
using KovserHedieyyeler.Application.Features.Commands.Employees.Create.CreateEmployeeAddress;
using KovserHedieyyeler.Application.Features.Commands.Employees.Delete.Permanently.RemoveEmployee;
using KovserHedieyyeler.Application.Features.Commands.Employees.Delete.Permanently.RemoveEmployeeAddress;
using KovserHedieyyeler.Application.Features.Commands.Employees.Delete.Temporarily;
using KovserHedieyyeler.Application.Features.Commands.Employees.Recover;
using KovserHedieyyeler.Application.Features.Commands.Employees.Update.UpdateEmployeeAddress;
using KovserHedieyyeler.Application.Features.Commands.Employees.Update.UpdateEmployees.UpdateEmployee;
using KovserHedieyyeler.Application.Features.Queries.Employees.GetAll.GetAllEmployeeAddresses;
using KovserHedieyyeler.Application.Features.Queries.Employees.GetAll.GetAllEmployees;
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

        [HttpGet("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployeesAsync([FromQuery] GetAllEmployeesQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Datas);
        }

        [HttpGet("GetAllEmployeeAddresses")]
        public async Task<IActionResult> GetAllEmployeeAddressesAsync([FromQuery] GetAllEmployeeAddressesQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Datas);
        }

        [HttpPost("CreateEmployee")]
        public async Task<IActionResult> CreateEmployeeAsync([FromForm] CreateEmployeeCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPost("CreateEmployeeAddress")]
        public async Task<IActionResult> CreateEmployeeAddressAsync([FromForm] CreateEmployeeAddressCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] string id)
        {
            var request = new GetSingleEmployeeQueryRequest
            {
                Id = id
            };

            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Dto);
        }

        [HttpDelete("DeleteTemporarily/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] string id)
        {
            var request = new DeleteTemporarilyEmployeeCommandRequest
            {
                Id = id
            };

            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpDelete("RemovePermanentlyEmployee/{id}")]
        public async Task<IActionResult> RemoveEmployeeAsync([FromRoute] string id)
        {
            var request = new RemovePermanentlyEmployeeCommandRequest
            {
                Id = id
            };

            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpDelete("RemovePermanentlyEmployeeAddress/{id}")]
        public async Task<IActionResult> RemoveEmployeeAddressAsync([FromRoute] string id)
        {
            var request = new RemoveEmployeeAddressCommandRequest
            {
                Id = id,
            };

            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPut("RecoverData/{id}")]
        public async Task<IActionResult> RecoverDataAsync([FromRoute] string id)
        {
            var request = new RecoverEmployeeCommandRequest
            {
                Id = id
            };

            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPut("UpdateTotalEmployee")]
        public async Task<IActionResult> UpdateTotalEmployeeAsync([FromForm] UpdateTotalEmployeeCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPut("UpdateEmployeeAddress")]
        public async Task<IActionResult> UpdateEmployeeAddressAsync([FromForm] UpdateEmployeeAddressCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateEmployeeAsync([FromForm] UpdateEmployeeCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
