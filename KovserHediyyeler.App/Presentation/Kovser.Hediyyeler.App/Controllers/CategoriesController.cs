using KovserHedieyyeler.Application.DTOs.Categories;
using KovserHedieyyeler.Application.Exceptions.BadRequestExceptions;
using KovserHedieyyeler.Application.Features.Commands.Brands.Delete.Permanently;
using KovserHedieyyeler.Application.Features.Commands.Categories.Create;
using KovserHedieyyeler.Application.Features.Commands.Categories.Delete.Permanently;
using KovserHedieyyeler.Application.Features.Commands.Categories.Delete.Temporarily;
using KovserHedieyyeler.Application.Features.Commands.Categories.Update;
using KovserHedieyyeler.Application.Features.Queries.Categories.GetAll;
using KovserHedieyyeler.Application.Features.Queries.Categories.GetSingle;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kovser.Hediyyeler.App.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] GetAllCategoriesQueryRequest request)
        {
            GetAllCategoriesQueryResponse response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Datas);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CategoryCommandDto dto)
        {
            if (dto == null) throw new BadRequestException();
            CreateCategoryCommandRequest request = new CreateCategoryCommandRequest
            {
                Dto = dto
            };
            CreateCategoryCommandResponse response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            if (id == null) throw new BadRequestException();
            GetSingleCategoryQueryRequest request = new GetSingleCategoryQueryRequest
            {
                Id = id
            };
            GetSingleCategoryQueryResponse response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Dto);
        }

        [HttpDelete("DeleteTemporarily, {id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            if (id == null) throw new BadRequestException();
            DeleteTemporarilyCategoryCommandRequest request = new DeleteTemporarilyCategoryCommandRequest 
            { 
                Id = id 
            };
            DeleteTemporarilyCategoryCommandResponse response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpDelete("RemovePermanently, {id}")]
        public async Task<IActionResult> RemoveAsync(string id)
        {
            if (id == null) throw new BadRequestException();
            RemovePermanentlyCategoryCommandRequest request = new RemovePermanentlyCategoryCommandRequest 
            { 
                Id = id 
            };
            RemovePermanentlyCategoryCommandResponse response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(CategoryCommandDto dto, string id)
        {
            if (dto == null) throw new BadRequestException();
            UpdateCategoryCommandRequest request = new UpdateCategoryCommandRequest
            {
                Id = id,
                Dto = dto
            };
            UpdateCategoryCommandResponse response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
