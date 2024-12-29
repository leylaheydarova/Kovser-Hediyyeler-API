using KovserHediyyeler.Domain.Enums;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Orders.ApproveOrder.OrderPayment
{
    public class ApproveOrderPaymentCommandRequest : IRequest<ApproveOrderPaymentCommandResponse>
    {
        public string CustomerId { get; set; }
        public PaymentStatus Status { get; set; }
        public Guid OrderId { get; set; }
        public ShippingType Type { get; set; }
    }
}
