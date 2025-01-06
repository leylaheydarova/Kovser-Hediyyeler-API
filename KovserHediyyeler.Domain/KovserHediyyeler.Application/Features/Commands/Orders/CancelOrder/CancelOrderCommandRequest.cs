using KovserHedieyyeler.Application.Features.Commands;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Orders.CancelOrder
{
    public class CancelOrderCommandRequest : DeleteCommandRequest, IRequest<CancelOrderCommandResponse>
    {
    }
}
