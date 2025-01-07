using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.Orders.GetAll.OrderDetails
{
    public class GetAllOrderDetailsQueryHandler : IRequestHandler<GetAllOrderDetailsQueryRequest, GetAllOrderDetailsQueryResponse>
    {
        readonly IOrderService _service;

        public GetAllOrderDetailsQueryHandler(IOrderService service)
        {
            _service = service;
        }

        public async Task<GetAllOrderDetailsQueryResponse> Handle(GetAllOrderDetailsQueryRequest request, CancellationToken cancellationToken)
        {
            var dtos = await _service.GetAllOrderDetailsAsync(request.OrderId);
            return new GetAllOrderDetailsQueryResponse
            {
                Datas = dtos,
                TotalCount = dtos.Count
            };
        }
    }
}
