using KovserHedieyyeler.Application.DTOs.Products.ProductProperty;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Create.CreateProductProperty
{
    public class CreateProductPropertyCommandRequest : CreateCommandRequest<ProductPropertyCommandDto>, IRequest<CreateProductPropertyCommandResponse>
    {
        public Guid ProductId { get; set; }
    }
}
