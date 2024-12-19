//using KovserHediyyeler.Application.Abstractions;
//using KovserHediyyeler.Application.Exceptions.FailExceptions;
//using MediatR;

//namespace KovserHediyyeler.Application.Features.Commands.Orders.Create.CreateOrder
//{
//    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
//    {
//        readonly IOrderService _service;

//        public CreateOrderCommandHandler(IOrderService service)
//        {
//            _service = service;
//        }

//        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
//        {
//            var result = await _service.CreateOrderAsync(request.CustomerId, request.Dto);
//            if (!result) throw new FailException("Sifari yaradılarkən, gözlənilməz xəta baş verdi. Zəhmət olmasa yenidən cəhd edin.");
//            return new CreateOrderCommandResponse
//            {
//                StatusCode = 201,
//                Message = "Sifarişiniz alındı!"
//            };
//        }

//    }
//}
