using KovserHedieyyeler.Application.DTOs.Products.ProductProperty;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Update.UpdateProductProperties
{
    public class UpdateProductPropertyCommandRequest:UpdateCommandRequest<ProductPropertyCommandDto>, IRequest<UpdateProductPropertyCommandResponse>
    {
    }
}
