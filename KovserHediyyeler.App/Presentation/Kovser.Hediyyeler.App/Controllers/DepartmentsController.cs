using KovserHedieyyeler.Application.DTOs.Department;
using KovserHedieyyeler.Application.Exceptions.BadRequestExceptions;
using KovserHedieyyeler.Application.Features.Commands.Departments.Create;
using KovserHedieyyeler.Application.Features.Commands.Departments.Update;
using KovserHedieyyeler.Application.Features.Queries.Departments.GetAll;
using KovserHedieyyeler.Application.Features.Queries.Departments.GetSingle;
using MediatR;
using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var request = new GetAllDepartmentsQueryRequest();
            if (request == null) throw new BadRequestException();
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Datas);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm]DepartmentCommandDto dto)
        {
            var request = new CreateDepartmentCommandRequest
            {
                Name = dto.Name,
                Description = dto.Description,
                Phone = dto.Phone,
                file = dto.file,
                //Nickname
                //Url
                //LinkName
            };

            if(request == null) throw new BadRequestException();

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
            var request = new UpdateDepartmentCommandRequest
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
            var request = new UpdateDepartmentCommandRequest
            {
                Id = id
            };
            if (request == null) throw new BadRequestException();

            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromForm]DepartmentCommandDto dto, string id)
        {
            var request = new UpdateDepartmentCommandRequest 
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
