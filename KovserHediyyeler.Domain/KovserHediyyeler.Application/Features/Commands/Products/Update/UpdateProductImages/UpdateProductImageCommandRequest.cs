using KovserHedieyyeler.Application.DTOs.Products.ProductImage;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Update.UpdateProductImages
{
    public class UpdateProductImageCommandRequest:UpdateCommandRequest<ProductImageCommandDto>, IRequest<UpdateProductImageCommandResponse>
    {
    }
}
