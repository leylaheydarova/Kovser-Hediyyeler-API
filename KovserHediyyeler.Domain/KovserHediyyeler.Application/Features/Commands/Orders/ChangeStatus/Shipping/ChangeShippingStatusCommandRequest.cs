using KovserHedieyyeler.Application.Features;
using KovserHediyyeler.Domain.Enums;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Orders.ChangeStatus.Shipping
{
    public class ChangeShippingStatusCommandRequest : IdRequest, IRequest<ChangeShippingStatusCommandResponse>
    {
        public ShippingStatus Status { get; set; }
    }
}
