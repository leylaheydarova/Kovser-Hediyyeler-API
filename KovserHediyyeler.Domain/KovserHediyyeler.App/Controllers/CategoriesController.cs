using KovserHedieyyeler.Application.DTOs.Categories;
using KovserHedieyyeler.Application.Exceptions.BadRequestExceptions;
using KovserHedieyyeler.Application.Features.Commands.Categories.Create;
using KovserHedieyyeler.Application.Features.Commands.Categories.Delete.Permanently;
using KovserHedieyyeler.Application.Features.Commands.Categories.Delete.Temporarily;
using KovserHedieyyeler.Application.Features.Commands.Categories.Update.TotalUpdate;
using KovserHedieyyeler.Application.Features.Commands.Categories.Update.UpdatePartly;
using KovserHedieyyeler.Application.Features.Queries.Categories.GetAll.GetAllAbstractParents;
using KovserHedieyyeler.Application.Features.Queries.Categories.GetAll.GetAllCategories;
using KovserHedieyyeler.Application.Features.Queries.Categories.GetSingle;
using KovserHediyyeler.Application.Features.Commands.Categories.Update.Recover;
using KovserHediyyeler.Application.Features.Queries.Categories.GetAll.GetAllChilds;
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
        //[Authorize(Roles = "Client")]
        public async Task<IActionResult> GetAllAsync()
        {
            var request = new GetAllCategoriesQueryRequest();
            GetAllCategoriesQueryResponse response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Datas);
        }

        [HttpGet("GetAllTopCategories")]
        public async Task<IActionResult> GetAllTopCategoriesAsync([FromQuery] GetAllTopParentsQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Datas);
        }

        [HttpGet("GetAllChildCategories")]
        public async Task<IActionResult> GetAllChildCategoriesAsync([FromQuery] GetAllChildsQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Datas);
        }

        //[AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Create Category", Menu = AuthorizeDefinitionConstants.Categories)]
        [HttpPost("CreateCategory")]
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

        //[AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "Delete Temporarily Category", Menu = AuthorizeDefinitionConstants.Categories)]
        [HttpDelete("DeleteTemporarily/{id}")]
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

        //[AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "Remove Permanently Category", Menu = AuthorizeDefinitionConstants.Categories)]
        [HttpDelete("RemovePermanently/{id}")]
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

        //[AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Update Total Category", Menu = AuthorizeDefinitionConstants.Categories)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTotalAsync(CategoryCommandDto dto, string id)
        {
            if (dto == null) throw new BadRequestException();
            UpdateTotalCategoryCommandRequest request = new UpdateTotalCategoryCommandRequest
            {
                Id = id,
                Dto = dto
            };
            UpdateTotalCategoryCommandResponse response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        //[AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Recover Deleted Category", Menu = AuthorizeDefinitionConstants.Categories)]
        [HttpPatch("RecoverData/{id}")]
        public async Task<IActionResult> RecoverDataAsync(RecoverCategoryCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        //[AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Update Category", Menu = AuthorizeDefinitionConstants.Categories)]
        [HttpPatch("UpdateCategory")]
        public async Task<IActionResult> UpdateAsync(UpdateCategoryCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
