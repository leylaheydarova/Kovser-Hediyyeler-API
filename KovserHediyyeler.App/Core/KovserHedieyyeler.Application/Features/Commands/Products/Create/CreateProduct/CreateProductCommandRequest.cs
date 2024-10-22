using KovserHedieyyeler.Application.DTOs.Products.Products;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Create.CreateProduct
{
    public class CreateProductCommandRequest:CreateCommandRequest<ProductPostDto>, IRequest<CreateProductCommandResponse>
    {
    }
}
