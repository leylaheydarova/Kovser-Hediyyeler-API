using KovserHediyyeler.Application.Abstractions;
using MediatR;


namespace KovserHedieyyeler.Application.Features.Queries.Shops.GetAll.GetAllShops
{
    public class GetAllShopsQueryHandler : IRequestHandler<GetAllShopsQueryRequest, GetAllShopsQueryResponse>
    {
        readonly IShopService _service;

        public GetAllShopsQueryHandler(IShopService service)
        {
            _service = service;
        }

        public async Task<GetAllShopsQueryResponse> Handle(GetAllShopsQueryRequest request, CancellationToken cancellationToken)
        {
            var dtos = await _service.GetAllShopsAsync(request.Page, request.Size);

            return new GetAllShopsQueryResponse
            {
                Datas = dtos,
                TotalCount = dtos.Count()
            };
        }
    }
}
