
using KovserHedieyyeler.Application.DTOs.Brands;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Brands.Update
{
    public class UpdateBrandCommandRequest:UpdateCommandRequest<BrandCommandDto>, IRequest<UpdateBrandCommandResponse>
    {
    }
}
