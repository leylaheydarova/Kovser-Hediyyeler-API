using KovserHedieyyeler.Application.DTOs.Brands;
using KovserHedieyyeler.Application.Features.Commands.Brands.Create;
using KovserHedieyyeler.Application.Features.Commands.Brands.Delete.Permanently;
using KovserHedieyyeler.Application.Features.Commands.Brands.Delete.Temporarily;
using KovserHedieyyeler.Application.Features.Commands.Brands.Update;
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
        public async Task<IActionResult> GetAllAsync()
        {
            GetAllBrandsQueryRequest request = new GetAllBrandsQueryRequest();
            GetAllBrandsQueryResponse response = await _mediator.Send(request);
            return StatusCode(200, response.Dtos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm]BrandCommandDto dto)
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
        public async Task<IActionResult> GetByIdAsync([FromRoute]GetSingleBrandQueryRequest request)
        {
            GetSingleBrandQueryResponse response = await _mediator.Send(request);
            return StatusCode(200, response.Dto);
        }

        [HttpDelete("DeleteTemporarily")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            DeleteTemporarilyBrandCommandRequest request = new DeleteTemporarilyBrandCommandRequest
            {
                Id = id
            };
            DeleteTemporarilyBrandCommandResponse response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }


        [HttpDelete("DeletePermanently")]
        public async Task<IActionResult> RemoveAsync(string id)
        {
            RemovePermanentlyBrandCommandRequest request = new RemovePermanentlyBrandCommandRequest
            {
                Id = id
            };
            RemovePermanentlyBrandCommandResponse response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }



        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateAsync([FromForm]BrandCommandDto dto, string id)
        {
            if(dto == null)
            {
                return BadRequest();
            }

            UpdateBrandCommandRequest request = new UpdateBrandCommandRequest
            {
                Dto = dto,
                Id = id
            };

            UpdateBrandCommandResponse response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response?.Message);
        }
    }
}
