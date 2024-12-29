using KovserHediyyeler.Application.DTOs.Orders;
using KovserHediyyeler.Application.Features.Commands.Orders.ApproveOrder.OrderPayment;
using KovserHediyyeler.Application.Features.Commands.Orders.Create.CreateOrder;
using KovserHediyyeler.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KovserHediyyeler.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create-order")]
        public async Task<IActionResult> CreateOrderAsync(string customerId, OrderDto dto)
        {
            var request = new CreateOrderCommandRequest
            {
                CustomerId = customerId,
                Dto = dto
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPost("approve-order-payment")]
        public async Task<IActionResult> ApproveOrderPaymentAsync(string customerId, PaymentStatus status, Guid orderId, ShippingType type)
        {
            var request = new ApproveOrderPaymentCommandRequest
            {
                CustomerId = customerId,
                OrderId = orderId,
                Status = status,
                Type = type
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
