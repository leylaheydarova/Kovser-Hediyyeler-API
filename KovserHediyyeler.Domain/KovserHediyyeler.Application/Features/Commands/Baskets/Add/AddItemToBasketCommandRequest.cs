using KovserHediyyeler.Application.DTOs.Baskets;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Baskets.Add
{
    public class AddItemToBasketCommandRequest : BasketCommandRequest<BasketCommandDto>, IRequest<AddItemToBasketCommandResponse>
    {

    }
}
