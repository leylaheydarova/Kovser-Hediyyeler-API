using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Shops.GetSingle
{
    public class GetSingleShopQueryHandler : IRequestHandler<GetSingleShopQueryRequest, GetSingleShopQueryResponse>
    {
        readonly IShopService _service;

        public GetSingleShopQueryHandler(IShopService service)
        {
            _service = service;
        }

        public async Task<GetSingleShopQueryResponse> Handle(GetSingleShopQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = await _service.GetSingleShopAsync(request.Id);

            return new GetSingleShopQueryResponse
            {
                Dto = dto
            };
        }
    }
}
