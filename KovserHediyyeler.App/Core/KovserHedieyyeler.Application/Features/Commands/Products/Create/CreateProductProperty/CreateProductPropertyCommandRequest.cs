using KovserHedieyyeler.Application.DTOs.Products.ProductProperty;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Create.CreateProductProperty
{
    public class CreateProductPropertyCommandRequest:CreateCommandRequest<ProductPropertyPostDto>, IRequest<CreateProductPropertyCommandResponse>
    {
        public string ProductId { get; set; }
    }
}
