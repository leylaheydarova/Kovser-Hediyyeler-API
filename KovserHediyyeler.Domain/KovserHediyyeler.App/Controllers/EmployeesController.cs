using KovserHedieyyeler.Application.Features.Commands.Employees.Create.CreateEmployee;
using KovserHedieyyeler.Application.Features.Commands.Employees.Create.CreateEmployeeAddress;
using KovserHedieyyeler.Application.Features.Commands.Employees.Delete.Permanently.RemoveEmployee;
using KovserHedieyyeler.Application.Features.Commands.Employees.Delete.Temporarily;
using KovserHedieyyeler.Application.Features.Commands.Employees.Update.UpdateEmployeeAddress;
using KovserHedieyyeler.Application.Features.Commands.Employees.Update.UpdateEmployees.UpdateEmployee;
using KovserHedieyyeler.Application.Features.Queries.Employees.GetAll.GetAllEmployeeAddresses;
using KovserHedieyyeler.Application.Features.Queries.Employees.GetAll.GetAllEmployees;
using KovserHedieyyeler.Application.Features.Queries.Employees.GetSingle;
using KovserHediyyeler.Application.Features.Commands.Employees.Delete.Permanently.RemoveEmployeeAddress;
using KovserHediyyeler.Application.Features.Commands.Employees.Update.Recover;
using KovserHediyyeler.Application.Features.Commands.Employees.Update.UpdateEmployees.UpdateTotalEmployee;
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


        //[AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Create Employee", Menu = AuthorizeDefinitionConstants.Empoyees)]
        [HttpPost("CreateEmployee")]
        public async Task<IActionResult> CreateEmployeeAsync([FromForm] CreateEmployeeCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        //[AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Add Employee's Address", Menu = AuthorizeDefinitionConstants.Empoyees)]
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
                Id = Guid.Parse(id)
            };

            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Dto);
        }

        //[AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "Delete Temporarily Employee", Menu = AuthorizeDefinitionConstants.Empoyees)]
        [HttpDelete("DeleteTemporarily/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] string id)
        {
            var request = new DeleteTemporarilyEmployeeCommandRequest
            {
                Id = Guid.Parse(id)
            };

            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }
        //
        //    //[AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "Remove Permanently Employee", Menu = AuthorizeDefinitionConstants.Empoyees)]
        [HttpDelete("RemovePermanentlyEmployee/{id}")]
        public async Task<IActionResult> RemoveEmployeeAsync([FromRoute] string id)
        {
            var request = new RemovePermanentlyEmployeeCommandRequest
            {
                Id = Guid.Parse(id)
            };

            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        //  [AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "Remove Permanently Employee's Address", Menu = AuthorizeDefinitionConstants.Empoyees)]
        [HttpDelete("RemovePermanentlyEmployeeAddress/{id}")]
        public async Task<IActionResult> RemoveEmployeeAddressAsync([FromRoute] string id)
        {
            var request = new RemoveAddressCommandRequest
            {
                Id = Guid.Parse(id),
            };

            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        // [AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Recover Deleted Employee", Menu = AuthorizeDefinitionConstants.Empoyees)]
        [HttpPatch("RecoverData/{id}")]
        public async Task<IActionResult> RecoverDataAsync([FromRoute] string id)
        {
            var request = new RecoverEmployeeCommandRequest
            {
                Id = Guid.Parse(id)
            };

            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        // [AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Update Total Employee", Menu = AuthorizeDefinitionConstants.Empoyees)]
        [HttpPut("UpdateTotalEmployee")]
        public async Task<IActionResult> UpdateTotalEmployeeAsync([FromForm] UpdateTEmployeeCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        // [AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Update Employee", Menu = AuthorizeDefinitionConstants.Empoyees)]
        [HttpPatch("UpdateEmployeeAddress")]
        public async Task<IActionResult> UpdateEmployeeAddressAsync([FromForm] UpdateEmployeeAddressCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        //[AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Update Employee's Address", Menu = AuthorizeDefinitionConstants.Empoyees)]
        [HttpPatch("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployeeAsync([FromForm] UpdateEmployeeCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
