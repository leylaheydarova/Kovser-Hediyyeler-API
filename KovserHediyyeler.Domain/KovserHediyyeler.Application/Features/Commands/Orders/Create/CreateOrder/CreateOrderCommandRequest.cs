using KovserHedieyyeler.Application.Features.Commands;
using KovserHediyyeler.Application.DTOs.Orders;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Orders.Create.CreateOrder
{
    public class CreateOrderCommandRequest : CreateCommandRequest<OrderDto>, IRequest<CreateOrderCommandResponse>
    {
        public string CustomerId { get; set; }
    }
}
