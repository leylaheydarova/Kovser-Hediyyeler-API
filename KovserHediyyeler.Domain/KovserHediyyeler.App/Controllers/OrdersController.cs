//using KovserHediyyeler.Application.DTOs.Orders;
//using KovserHediyyeler.Application.Features.Commands.Orders.Create.CreateOrder;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;

//namespace KovserHediyyeler.App.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class OrdersController : ControllerBase
//    {
//        readonly IMediator _mediator;

//        public OrdersController(IMediator mediator)
//        {
//            _mediator = mediator;
//        }

//        [HttpPost("create-order")]
//        public async Task<IActionResult> CreateOrderAsync(string customerId, OrderDto dto)
//        {
//            var request = new CreateOrderCommandRequest
//            {
//                CustomerId = customerId,
//                Dto = dto
//            };
//            var response = await _mediator.Send(request);
//            return StatusCode(response.StatusCode, response.Message);
//        }
//    }
//}
