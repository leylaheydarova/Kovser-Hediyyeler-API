using KovserHedieyyeler.Application.Features;
using KovserHediyyeler.Domain.Enums;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Orders.ChangeStatus.Order
{
    public class ChangeOrderStatusCommandRequest : IdRequest, IRequest<ChangeOrderStatusCommandResponse>
    {
        public OrderStatus Status { get; set; }
    }
}
