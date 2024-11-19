using KovserHedieyyeler.Application.Features.Commands;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Promotions.Delete
{
    public class RemovePromotionCommandRequest : DeleteCommandRequest, IRequest<RemovePromotionCommandResponse>
    {
    }
}
