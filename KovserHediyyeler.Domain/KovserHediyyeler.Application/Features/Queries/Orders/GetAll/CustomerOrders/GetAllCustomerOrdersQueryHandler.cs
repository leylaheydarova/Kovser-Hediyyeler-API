using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.Orders.GetAll.CustomerOrders
{
    public class GetAllCustomerOrdersQueryHandler : IRequestHandler<GetAllCustomerOrdersQueryRequest, GetAllCustomerOrdersQueryResponse>
    {
        readonly IOrderService _service;

        public GetAllCustomerOrdersQueryHandler(IOrderService service)
        {
            _service = service;
        }

        public async Task<GetAllCustomerOrdersQueryResponse> Handle(GetAllCustomerOrdersQueryRequest request, CancellationToken cancellationToken)
        {
            var dtos = await _service.GetAllCustomerOrdersAsync(request.Page, request.Size, request.CustomerId);
            return new GetAllCustomerOrdersQueryResponse
            {
                Datas = dtos,
                TotalCount = dtos.Count
            };
        }
    }
}
