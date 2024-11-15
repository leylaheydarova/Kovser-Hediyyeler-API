using KovserHedieyyeler.Application.DTOs.Products.Products;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Update.UpdateProducts
{
    public class UpdateProductCommandRequest : UpdateCommandRequest<ProductPutDto>, IRequest<UpdateProductCommandResponse>
    {
    }
}
