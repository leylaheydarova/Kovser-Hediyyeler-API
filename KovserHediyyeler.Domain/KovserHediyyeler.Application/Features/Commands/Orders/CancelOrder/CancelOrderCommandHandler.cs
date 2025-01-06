using KovserHedieyyeler.Application.Exceptions.BadRequestExceptions;
using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Orders.CancelOrder
{
    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommandRequest, CancelOrderCommandResponse>
    {
        readonly IOrderService _service;

        public CancelOrderCommandHandler(IOrderService service)
        {
            _service = service;
        }

        public async Task<CancelOrderCommandResponse> Handle(CancelOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _service.CancelOrderAsync(Guid.Parse(request.Id));
            if (!result) throw new BadRequestException();
            return new CancelOrderCommandResponse
            {
                Message = "Sifariş ləğv olundu!"
            };
        }
    }
}
