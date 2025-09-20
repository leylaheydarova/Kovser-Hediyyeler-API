using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.Orders.GetSingle.Order
{
    public class GetSingleOrderQueryHandler : IRequestHandler<GetSingleOrderQueryRequest, GetSingleOrderQueryResponse>
    {
        readonly IOrderService _service;

        public GetSingleOrderQueryHandler(IOrderService service)
        {
            _service = service;
        }

        public async Task<GetSingleOrderQueryResponse> Handle(GetSingleOrderQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = await _service.GetSingleOrderAsync(request.Id);
            return new GetSingleOrderQueryResponse
            {
                Dto = dto
            };
        }
    }
}
