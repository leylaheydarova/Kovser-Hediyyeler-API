using KovserHedieyyeler.Application.Features.Commands;
using KovserHediyyeler.Application.DTOs.Promotion;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Promotions.Update
{
    public class UpdatePromotionCommandRequest : UpdateCommandRequest<PromotionPatchDto>, IRequest<UpdatePromotionCommandResponse>
    {
    }
}
