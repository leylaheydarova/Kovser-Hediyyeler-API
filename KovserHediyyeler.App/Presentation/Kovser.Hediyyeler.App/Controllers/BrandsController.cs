using KovserHedieyyeler.Application.Const;
using KovserHedieyyeler.Application.CustomAttributes;
using KovserHedieyyeler.Application.DTOs.Brands;
using KovserHedieyyeler.Application.Enums;
using KovserHedieyyeler.Application.Features.Commands.Brands.Create;
using KovserHedieyyeler.Application.Features.Commands.Brands.Delete.Permanently;
using KovserHedieyyeler.Application.Features.Commands.Brands.Delete.Temporarily;
using KovserHedieyyeler.Application.Features.Commands.Brands.Recover;
using KovserHedieyyeler.Application.Features.Commands.Brands.Update.Update;
using KovserHedieyyeler.Application.Features.Commands.Brands.Update.UpdateAll;
using KovserHedieyyeler.Application.Features.Queries.Brands.GetAll;
using KovserHedieyyeler.Application.Features.Queries.Brands.GetSingle;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kovser.Hediyyeler.App.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        readonly IMediator _mediator;

        public BrandsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] GetAllBrandsQueryRequest request)
        {
            GetAllBrandsQueryResponse response = await _mediator.Send(request);
            return StatusCode(200, response.Datas);
        }

        [AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Create Brand", Menu = AuthorizeDefinitionConstants.Brands)]
        [HttpPost("CreateBrand")]
        public async Task<IActionResult> CreateAsync([FromForm] BrandCommandDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            var request = new CreateBrandCommandRequest
            {
                Dto = dto
            };

            CreateBrandCommandResponse response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] GetSingleBrandQueryRequest request)
        {
            GetSingleBrandQueryResponse response = await _mediator.Send(request);
            return StatusCode(200, response.Dto);
        }

        [AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "Delete Temporarily Brand", Menu = AuthorizeDefinitionConstants.Brands)]
        [HttpDelete("DeleteTemporarily/{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            DeleteTemporarilyBrandCommandRequest request = new DeleteTemporarilyBrandCommandRequest
            {
                Id = id
            };
            DeleteTemporarilyBrandCommandResponse response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }


        [AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "Remove Permanently Brand", Menu = AuthorizeDefinitionConstants.Brands)]
        [HttpDelete("RemovePermanently/{id}")]
        public async Task<IActionResult> RemoveAsync(string id)
        {
            var request = new RemovePermanentlyBrandCommandRequest
            {
                Id = id
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }



        [AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Update Total Brand", Menu = AuthorizeDefinitionConstants.Brands)]
        [HttpPut("UpdateTotalBrand")]
        public async Task<IActionResult> UpdateAllAsync([FromForm] UpdateTotalBrandCommandRequest request)
        {
            UpdateTotalBrandCommandResponse response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response?.Message);
        }

        [AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Recover Deleted Brand", Menu = AuthorizeDefinitionConstants.Brands)]
        [HttpPatch("RecoverData/{id}")]
        public async Task<IActionResult> RecoverDataAsync(string id)
        {
            var request = new RecoverCategoryRequest
            {
                Id = id
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Update Brand", Menu = AuthorizeDefinitionConstants.Brands)]
        [HttpPatch("UpdateBrand")]
        public async Task<IActionResult> UpdateAsync([FromForm] UpdateBrandCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
