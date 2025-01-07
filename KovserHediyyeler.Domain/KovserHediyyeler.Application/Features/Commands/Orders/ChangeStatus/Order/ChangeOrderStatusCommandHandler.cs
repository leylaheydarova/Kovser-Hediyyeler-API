using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Orders.ChangeStatus.Order
{
    public class ChangeOrderStatusCommandHandler : IRequestHandler<ChangeOrderStatusCommandRequest, ChangeOrderStatusCommandResponse>
    {
        readonly IOrderService _service;

        public ChangeOrderStatusCommandHandler(IOrderService service)
        {
            _service = service;
        }

        public async Task<ChangeOrderStatusCommandResponse> Handle(ChangeOrderStatusCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.ChangeOrderStatusAsync(Guid.Parse(request.Id), request.Status);
            return new ChangeOrderStatusCommandResponse
            {
                Message = "Sifarişin statusu uğurla dəyişdi!"
            };
        }
    }
}
