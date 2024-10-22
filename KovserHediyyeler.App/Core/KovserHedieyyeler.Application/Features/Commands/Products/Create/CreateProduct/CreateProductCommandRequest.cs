using KovserHedieyyeler.Application.DTOs.Products;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Create.CreateProduct
{
    public class CreateProductCommandRequest:CreateCommandRequest<ProductPostDto>, IRequest<CreateProductCommandResponse>
    {
    }
}
