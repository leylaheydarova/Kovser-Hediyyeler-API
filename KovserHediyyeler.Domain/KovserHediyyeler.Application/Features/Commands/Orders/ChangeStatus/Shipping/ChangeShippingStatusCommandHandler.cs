using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Orders.ChangeStatus.Shipping
{
    public class ChangeShippingStatusCommandHandler : IRequestHandler<ChangeShippingStatusCommandRequest, ChangeShippingStatusCommandResponse>
    {
        readonly IOrderService _service;

        public ChangeShippingStatusCommandHandler(IOrderService service)
        {
            _service = service;
        }

        public async Task<ChangeShippingStatusCommandResponse> Handle(ChangeShippingStatusCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.ChangeShippingStatusAsync(Guid.Parse(request.Id), request.Status);
            return new ChangeShippingStatusCommandResponse
            {
                Message = "Çatdırılma statusu uğurla dəyişdi!"
            };
        }
    }
}
