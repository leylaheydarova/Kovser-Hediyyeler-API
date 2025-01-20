using KovserHedieyyeler.Application.DTOs.Department;
using KovserHedieyyeler.Application.Exceptions.BadRequestExceptions;
using KovserHedieyyeler.Application.Features.Commands.Departments.Create.CreateDepartment;
using KovserHedieyyeler.Application.Features.Commands.Departments.Create.CreateSocialMedia;
using KovserHedieyyeler.Application.Features.Commands.Departments.Delete.Permanently.RemoveSocialMedia;
using KovserHedieyyeler.Application.Features.Commands.Departments.Delete.Temporarily;
using KovserHedieyyeler.Application.Features.Commands.Departments.Update.UpdateDepartment.Update;
using KovserHedieyyeler.Application.Features.Commands.Departments.Update.UpdateDepartment.UpdateTotal;
using KovserHedieyyeler.Application.Features.Commands.Departments.Update.UpdateSocialMedia;
using KovserHedieyyeler.Application.Features.Queries.Departments.GetAll.GetAllDepartments;
using KovserHedieyyeler.Application.Features.Queries.Departments.GetAll.GetAllSocialMedias;
using KovserHedieyyeler.Application.Features.Queries.Departments.GetSingle;
using KovserHediyyeler.Application.Features.Commands.Departments.Delete.Permanently.RemoveDepartment;
using KovserHediyyeler.Application.Features.Commands.Departments.Update.Recover;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kovser.Hediyyeler.App.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        readonly IMediator _mediator;

        public DepartmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Departments")]
        public async Task<IActionResult> GetAllDepartmentsAsync()
        {
            var request = new GetAllDepartmentsQueryRequest();
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Datas);
        }


        //[AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Create Department", Menu = AuthorizeDefinitionConstants.Departments)]
        [HttpPost("CreateDepartment")]
        public async Task<IActionResult> CreateDepartmentAsync([FromForm] CreateDepartmentCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpGet("SocialMedias")]
        public async Task<IActionResult> GetAllSocialMediasAsync([FromQuery] GetAllSocialMediasQueryRequest request)
        {

            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Datas);
        }

        // [AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Add Department's SocialMedia", Menu = AuthorizeDefinitionConstants.Departments)]
        [HttpPost("SocialMedia")]
        public async Task<IActionResult> CreateSocialMediaAsync([FromForm] CreateSocialMediaCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var request = new GetSingleDepartmentQueryRequest
            {
                Id = Guid.Parse(id)
            };

            if (request == null) throw new BadRequestException();

            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Dto);
        }

        //  [AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "Delete Temporarily Department", Menu = AuthorizeDefinitionConstants.Departments)]
        [HttpDelete("DeleteTemporarily")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var request = new DeleteTemporarilyDepartmentCommandRequest { Id = Guid.Parse(id) };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        // [AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "Remove Permanently Department", Menu = AuthorizeDefinitionConstants.Departments)]
        [HttpDelete("RemoveDepartment")]
        public async Task<IActionResult> RemoveDepartmentAsync(string id)
        {
            var request = new RemoveDepartmentCommandRequest { Id = Guid.Parse(id) };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        // [AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "Remove Permanently Department's Social Media", Menu = AuthorizeDefinitionConstants.Departments)]
        [HttpDelete("RemoveSocialMedia")]
        public async Task<IActionResult> RemoveSocialMediaAsync(string id)
        {
            var request = new RemoveSocialMediaCommandRequest { Id = Guid.Parse(id) };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        //  [AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Update Total Department", Menu = AuthorizeDefinitionConstants.Departments)]
        [HttpPut]
        public async Task<IActionResult> UpdateTotalAsync([FromForm] DepartmentCommandDto dto, string id)
        {
            var request = new UpdateTotalDepartmentCommandRequest
            {
                Dto = dto,
                Id = Guid.Parse(id)
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        // [AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Recover Deleted Department", Menu = AuthorizeDefinitionConstants.Departments)]
        [HttpPatch("RecoverData")]
        public async Task<IActionResult> RecoverDataAsync(string id)
        {
            var request = new RecoverDepartmentCommandRequest
            {
                Id = Guid.Parse(id)
            };

            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        //[AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Update Department", Menu = AuthorizeDefinitionConstants.Departments)]
        [HttpPatch("Department")]
        public async Task<IActionResult> UpdateAsync([FromForm] UpdateDepartmentCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        // [AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Update Department's Social Media", Menu = AuthorizeDefinitionConstants.Departments)]
        [HttpPatch("SocialMedia")]
        public async Task<IActionResult> UpdateSocialMediaAsync(UpdateSocialMediaCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
