using KovserHediyyeler.Application.DTOs.Baskets;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Baskets.Update.UpdateItemCount
{
    public class UpdateItemCountCommandRequest : BasketCommandRequest<BasketCommandDto>, IRequest<UpdateItemCountCommandResponse>
    {
    }
}
