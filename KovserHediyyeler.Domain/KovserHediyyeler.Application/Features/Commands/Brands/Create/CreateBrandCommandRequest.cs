using KovserHedieyyeler.Application.DTOs.Brands;
using MediatR;


namespace KovserHedieyyeler.Application.Features.Commands.Brands.Create
{
    public class CreateBrandCommandRequest:CreateCommandRequest<BrandCommandDto>, IRequest<CreateBrandCommandResponse>
    {
    }
}
