using KovserHedieyyeler.Application.DTOs.Department;
using KovserHedieyyeler.Application.DTOs.SocialMedias;
using KovserHedieyyeler.Application.Exceptions.BadRequestExceptions;
using KovserHedieyyeler.Application.Features.Commands.Departments.Create.CreateDepartment;
using KovserHedieyyeler.Application.Features.Commands.Departments.Create.CreateSocialMedia;
using KovserHedieyyeler.Application.Features.Commands.Departments.Delete.Permanently;
using KovserHedieyyeler.Application.Features.Commands.Departments.Delete.Permanently.RemoveDepartment;
using KovserHedieyyeler.Application.Features.Commands.Departments.Delete.Permanently.RemoveSocialMedia;
using KovserHedieyyeler.Application.Features.Commands.Departments.Delete.Temporarily;
using KovserHedieyyeler.Application.Features.Commands.Departments.Recover;
using KovserHedieyyeler.Application.Features.Commands.Departments.Update.UpdateDepartment.Update;
using KovserHedieyyeler.Application.Features.Commands.Departments.Update.UpdateDepartment.UpdateTotal;
using KovserHedieyyeler.Application.Features.Commands.Departments.Update.UpdateSocialMedia;
using KovserHedieyyeler.Application.Features.Queries.Departments.GetAll;
using KovserHedieyyeler.Application.Features.Queries.Departments.GetAll.GetAllDepartments;
using KovserHedieyyeler.Application.Features.Queries.Departments.GetAll.GetAllSocialMedias;
using KovserHedieyyeler.Application.Features.Queries.Departments.GetSingle;
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

        [HttpPost("Department")]
        public async Task<IActionResult> CreateDepartmentAsync([FromForm] CreateDepartmentCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpGet("SocialMedias/{Id}")]
        public async Task<IActionResult> GetAllSocialMediasAsync(string id)
        {
            var Id = id.ToString();
            var request = new GetAllSocialMediasQueryRequest()
            {
                DepartmentId = id
            };

            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Datas);
        }


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
                Id = id
            };

            if (request == null) throw new BadRequestException();

            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Dto);
        }

        [HttpDelete("DeleteTemporarily")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var request = new DeleteTemporarilyDepartmentCommandRequest { Id = id };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpDelete("RemoveDepartment")]
        public async Task<IActionResult> RemoveDepartmentAsync(string id)
        {
            var request = new RemovePermanentlyDepartmentCommandRequest { Id = id };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpDelete("RemoveSocialMedia")]
        public async Task<IActionResult> RemoveSocialMediaAsync(string id)
        {
            var request = new RemoveSocialMediaCommandRequest { Id = id };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTotalAsync([FromForm]DepartmentCommandDto dto, string id, string nickName)
        {
            var request = new UpdateTotalDepartmentCommandRequest
            {
                Dto = dto,
                Id = id,
                Nickname = nickName
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPut("RecoverData")]
        public async Task<IActionResult> RecoverDataAsync(string id)
        {
            var request = new RecoverDepartmentCommandRequest 
            { 
                Id = id 
            };

            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPatch("Department")]
        public async Task<IActionResult> UpdateAsync([FromForm]UpdateDepartmentCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPatch("SocialMedia")]
        public async Task<IActionResult> UpdateSocialMediaAsync(UpdateSocialMediaCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
