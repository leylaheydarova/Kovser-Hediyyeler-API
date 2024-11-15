using KovserHediyyeler.Application.Repositories.Products;
using KovserHediyyeler.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Create.CreateProductImage
{
    public class CreateProductImageCommandHandler : IRequestHandler<CreateProductImageCommandRequest, CreateProductImageCommandResponse>
    {
        readonly IProductImageFileWriteRepository _repository;
        readonly IHttpContextAccessor _accessor;

        public CreateProductImageCommandHandler(IProductImageFileWriteRepository repository, IHttpContextAccessor accessor)
        {
            _repository = repository;
            _accessor = accessor;
        }

        public async Task<CreateProductImageCommandResponse> Handle(CreateProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            ProductImageFile image = new ProductImageFile
            {
                ID = Guid.NewGuid(),
                FileName = request.Dto.file.FileName,
                Path = $"{_accessor.HttpContext.Request.Scheme}://{_accessor.HttpContext.Request.Host}/{request.Dto.file.FileName}",
                ProductID = Guid.Parse(request.ProductId),
                IsMain = request.Dto.IsMain
            };
            await _repository.AddAsync(image);
            await _repository.SaveAsync();

            return new CreateProductImageCommandResponse
            {
                StatusCode = 201,
                Message = "Məhsul şəkli uğurla yüklənmişdir"
            };
        }
    }
}
