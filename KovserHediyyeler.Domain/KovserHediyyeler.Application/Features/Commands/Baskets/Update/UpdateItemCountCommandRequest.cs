using KovserHediyyeler.Application.DTOs.Baskets;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Baskets.Update
{
    public class UpdateItemCountCommandRequest : BasketCommandRequest<BasketCommandDto>, IRequest<UpdateItemCountCommandResponse>
    {
    }
}
