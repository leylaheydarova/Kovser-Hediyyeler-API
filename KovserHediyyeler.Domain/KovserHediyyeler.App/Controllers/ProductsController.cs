using KovserHedieyyeler.Application.DTOs.Products.ProductImage;
using KovserHedieyyeler.Application.DTOs.Products.ProductProperty;
using KovserHedieyyeler.Application.DTOs.Products.Products;
using KovserHedieyyeler.Application.Features.Commands.Products.Create.CreateProduct;
using KovserHedieyyeler.Application.Features.Commands.Products.Create.CreateProductImage;
using KovserHedieyyeler.Application.Features.Commands.Products.Create.CreateProductProperty;
using KovserHedieyyeler.Application.Features.Commands.Products.Delete.Permanently.RemoveImage;
using KovserHedieyyeler.Application.Features.Commands.Products.Delete.Permanently.RemoveProducts;
using KovserHedieyyeler.Application.Features.Commands.Products.Delete.Permanently.RemoveProperty;
using KovserHedieyyeler.Application.Features.Commands.Products.Delete.Temporarily;
using KovserHedieyyeler.Application.Features.Commands.Products.Recover;
using KovserHedieyyeler.Application.Features.Commands.Products.Update.UpdateProductImages;
using KovserHedieyyeler.Application.Features.Commands.Products.Update.UpdateProductProperties;
using KovserHedieyyeler.Application.Features.Commands.Products.Update.UpdateProducts;
using KovserHedieyyeler.Application.Features.Queries.Products.GetAll.GetAllProductImages;
using KovserHedieyyeler.Application.Features.Queries.Products.GetAll.GetAllProductProperties;
using KovserHedieyyeler.Application.Features.Queries.Products.GetAll.GetAllProducts;
using KovserHedieyyeler.Application.Features.Queries.Products.GetSingle.GetSingleProduct;
using KovserHedieyyeler.Application.Features.Queries.Products.GetSingle.GetSingleProductProperty;
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

        [HttpGet("GetAllProductImagess")]
        public async Task<IActionResult> GetAllProductImagesAsync([FromQuery] GetAllProductImagesQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Datas);
        }

        [HttpGet("GetAllProductProperties")]
        public async Task<IActionResult> GetAllProductPropertiesAsync([FromQuery] GetAllProductPropertiesQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Datas);
        }

        // [AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Create Product", Menu = AuthorizeDefinitionConstants.Products)]
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProductAsync([FromForm] CreateProductCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        // [AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Create Product Image", Menu = AuthorizeDefinitionConstants.Products)]
        [HttpPost("CreateProductImage")]
        public async Task<IActionResult> CreateProductImageAsync([FromForm] CreateProductImageCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        //[AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Create Product Property", Menu = AuthorizeDefinitionConstants.Products)]
        [HttpPost("CreateProductProperty")]
        public async Task<IActionResult> CreateProductPropertyAsync([FromForm] CreateProductPropertyCommandRequest request)
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

        [HttpGet("GetSingleProductProperty/{id}")]
        public async Task<IActionResult> GetProductPropertyAsync(string id)
        {
            var request = new GetSingleProductPropertyQueryRequest
            {
                Id = id
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Dto);
        }

        // [AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "Delete Temporarily Product", Menu = AuthorizeDefinitionConstants.Products)]
        [HttpDelete("DeleteTemporarilyProduct/{id}")]
        public async Task<IActionResult> DeleteProductAsync(string id)
        {
            var request = new DeleteTemporarilyProductCommandRequest
            {
                Id = id
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        // [AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Recover Deleted Product", Menu = AuthorizeDefinitionConstants.Products)]
        [HttpPatch("RecoverProductData/{id}")]
        public async Task<IActionResult> RecoverProductAsync(string id)
        {
            var request = new RecoverProductCommandRequest
            {
                Id = id
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        // [AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "Remove Permanently Product", Menu = AuthorizeDefinitionConstants.Products)]
        [HttpDelete("RemovePermanentlyProduct/{id}")]
        public async Task<IActionResult> RemoveProductAsync(string id)
        {
            var request = new RemovePermanentlyProductCommandRequest
            {
                Id = id
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        // [AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "Remove Permanently Product Image", Menu = AuthorizeDefinitionConstants.Products)]
        [HttpDelete("RemovePermanentlyProductImage/{id}")]
        public async Task<IActionResult> RemoveProductImageAsync(string id)
        {
            var request = new RemoveProductImageCommandRequest
            {
                Id = id
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        // [AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "Remove Permanently Product Property", Menu = AuthorizeDefinitionConstants.Products)]
        [HttpDelete("RemovePermanentlyProductProperty/{id}")]
        public async Task<IActionResult> RemoveProductPropertyAsync(string id)
        {
            var request = new RemoveProductPropertyCommandRequest
            {
                Id = id
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        // [AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Update Product", Menu = AuthorizeDefinitionConstants.Products)]
        [HttpPatch("UpdateProductData/{id}")]
        public async Task<IActionResult> UpdateProductAsync(string id, ProductPutDto dto)
        {
            var request = new UpdateProductCommandRequest
            {
                Id = id,
                Dto = dto
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        // [AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Update Product Property", Menu = AuthorizeDefinitionConstants.Products)]
        [HttpPatch("UpdateProductPropertyData/{id}")]
        public async Task<IActionResult> UpdateProductPropertyAsync(string id, ProductPropertyCommandDto dto)
        {
            var request = new UpdateProductPropertyCommandRequest
            {
                Id = id,
                Dto = dto
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        // [AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Update Product Image", Menu = AuthorizeDefinitionConstants.Products)]
        [HttpPatch("UpdateProductImageData/{id}")]
        public async Task<IActionResult> UpdateProductImageAsync(string id, ProductImageCommandDto dto)
        {
            var request = new UpdateProductImageCommandRequest
            {
                Id = id,
                Dto = dto
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }
    }
}

