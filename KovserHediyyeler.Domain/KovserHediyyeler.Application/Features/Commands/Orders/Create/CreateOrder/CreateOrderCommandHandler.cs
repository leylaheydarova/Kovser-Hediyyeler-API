using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Orders.Create.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        readonly IOrderService _service;

        public CreateOrderCommandHandler(IOrderService service)
        {
            _service = service;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var isPaid = await _service.CreateOrderAsync(request.CustomerId, request.Dto);

            if (!isPaid)
            {
                return new CreateOrderCommandResponse
                {
                    StatusCode = 200,
                    Message = "Sifarişiniz ödəmə gözləməkdədir."
                };
            }
            return new CreateOrderCommandResponse
            {
                StatusCode = 201,
                Message = "Sifarişiniz alındı!"
            };
        }

    }
}
