using KovserHediyyeler.Application.DTOs.Orders;
using KovserHediyyeler.Application.Features.Commands.Orders.ApproveOrder.OrderPayment;
using KovserHediyyeler.Application.Features.Commands.Orders.CancelOrder;
using KovserHediyyeler.Application.Features.Commands.Orders.ChangeStatus.Order;
using KovserHediyyeler.Application.Features.Commands.Orders.ChangeStatus.Shipping;
using KovserHediyyeler.Application.Features.Commands.Orders.Create.CreateOrder;
using KovserHediyyeler.Application.Features.Queries.Orders.GetAll.CustomerOrders;
using KovserHediyyeler.Application.Features.Queries.Orders.GetAll.OrderDetails;
using KovserHediyyeler.Application.Features.Queries.Orders.GetAll.Orders;
using KovserHediyyeler.Application.Features.Queries.Orders.GetSingle.Order;
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

        [HttpGet("get-all-orders")]
        public async Task<IActionResult> GetAllOrdersAsync([FromQuery] GetAllOrdersQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Datas);
        }

        [HttpGet("get-all-customer-orders")]
        public async Task<IActionResult> GetAllCustomerOrdersAsync([FromQuery] GetAllCustomerOrdersQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Datas);
        }

        [HttpGet("get-all-order-details")]
        public async Task<IActionResult> GetAllOrderDetailsAsync([FromQuery] GetAllOrderDetailsQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Datas);
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

        [HttpGet("get-single-order/{id}")]
        public async Task<IActionResult> GetSingleOrderAsync(string id)
        {
            var request = new GetSingleOrderQueryRequest
            {
                Id = Guid.Parse(id)
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Dto);
        }

        [HttpDelete("cancel-order/{id}")]
        public async Task<IActionResult> CancelOrderAsync(string id)
        {
            var request = new CancelOrderCommandRequest
            {
                Id = Guid.Parse(id)
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPut("change-shipping-status")]
        public async Task<IActionResult> ChangeShippingStatusAsync(string id, ShippingStatus status)
        {
            var request = new ChangeShippingStatusCommandRequest
            {
                Id = id,
                Status = status
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPut("change-order-status")]
        public async Task<IActionResult> ChangeOrderStatusAsync(string id, OrderStatus status)
        {
            var request = new ChangeOrderStatusCommandRequest
            {
                Id = id,
                Status = status
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
