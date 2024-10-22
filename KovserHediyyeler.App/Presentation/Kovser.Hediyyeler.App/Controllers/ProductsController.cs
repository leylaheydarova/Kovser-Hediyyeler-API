using KovserHedieyyeler.Application.Features.Commands.Products.Create.CreateProduct;
using KovserHedieyyeler.Application.Features.Commands.Products.Create.CreateProductImage;
using KovserHedieyyeler.Application.Features.Commands.Products.Create.CreateProductProperty;
using KovserHedieyyeler.Application.Features.Queries.Products.GetAll;
using KovserHedieyyeler.Application.Features.Queries.Products.GetSingle;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kovser.Hediyyeler.App.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProductsAsync([FromQuery] GetAllProductsQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Datas);
        }

        //getAllImages

        //getAllProperties

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProductAsync([FromForm] CreateProductCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPost("CreateProductImage")]
        public async Task<IActionResult> CreateProductImageAsync([FromForm]CreateProductImageCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPost("CreateProductProperty")]
        public async Task<IActionResult> CreateProductPropertyAsync([FromForm]CreateProductPropertyCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpGet("GetSingleProduct/{id}")]
        public async Task<IActionResult> GetProductAsync(string id)
        {
            var request = new GetSingleProductQueryRequest
            {
                Id = id
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Dto);
        }

        //getsingleproperty

        //deleteproduct

        //recoverproduct

        //removeproduct

        //removeimage

        //removeproperty

        //updateproduct

        //updateproperty

        //updateimage
    }
}
