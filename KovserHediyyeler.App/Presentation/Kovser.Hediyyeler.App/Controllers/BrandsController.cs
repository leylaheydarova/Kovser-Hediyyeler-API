using KovserHedieyyeler.Application.Features.Commands.Brands.Create;
using KovserHedieyyeler.Application.Features.Commands.Brands.Update;
using KovserHedieyyeler.Application.Features.Queries.Brands.GetAll;
using KovserHedieyyeler.Application.Features.Queries.Brands.GetSingle;
using MediatR;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> GetAllAsync([FromBody]GetAllBrandsQueryRequest request)
        {
            GetAllBrandsQueryResponse response = await _mediator.Send(request);
            return StatusCode(200, response.Dtos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm]CreateBrandCommandRequest request)
        {
            CreateBrandCommandResponse response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute]GetSingleBrandQueryRequest request)
        {
            GetSingleBrandQueryResponse response = await _mediator.Send(request);
            return StatusCode(200, response.Dto);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateAsync([FromForm]UpdateBrandCommandRequest request)
        {
            UpdateBrandCommandResponse response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
