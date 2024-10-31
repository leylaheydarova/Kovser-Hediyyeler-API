using KovserHedieyyeler.Application.DTOs.Brands;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Brands.Update.UpdateAll
{
    public class UpdateTotalBrandCommandRequest : UpdateCommandRequest<BrandCommandDto>, IRequest<UpdateTotalBrandCommandResponse>
    {
    }
}
