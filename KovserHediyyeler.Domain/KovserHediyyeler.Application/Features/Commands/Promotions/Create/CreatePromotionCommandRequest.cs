using KovserHedieyyeler.Application.DTOs.Promotion;
using KovserHedieyyeler.Application.Features.Commands;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Promotions.Create
{
    public class CreatePromotionCommandRequest : CreateCommandRequest<PromotionCommandDto>, IRequest<CreatePromotionCommandResponse>
    {
    }
}
