using KovserHedieyyeler.Application.DTOs.Products.ProductImage;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Create.CreateProductImage
{
    public class CreateProductImageCommandRequest:CreateCommandRequest<ProductImagePostDto>, IRequest<CreateProductImageCommandResponse>
    {
        public string ProductId { get; set; }
    }
}
