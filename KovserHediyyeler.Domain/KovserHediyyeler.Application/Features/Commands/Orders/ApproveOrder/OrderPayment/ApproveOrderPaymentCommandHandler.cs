using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Exceptions.FailExceptions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Orders.ApproveOrder.OrderPayment
{
    public class ApproveOrderPaymentCommandHandler : IRequestHandler<ApproveOrderPaymentCommandRequest, ApproveOrderPaymentCommandResponse>
    {
        readonly IOrderService _service;

        public ApproveOrderPaymentCommandHandler(IOrderService service)
        {
            _service = service;
        }

        public async Task<ApproveOrderPaymentCommandResponse> Handle(ApproveOrderPaymentCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _service.ApproveOrderPaymentAsync(request.CustomerId, request.Status, request.OrderId, request.Type);
            if (!result) throw new FailException("Ödəniş zamanı xəta baş verdi");
            return new ApproveOrderPaymentCommandResponse
            {
                Message = "Ödəniş uğurlu oldu! Sifarişiniz təsdiqləndi!"
            };
        }
    }
}
