using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Shops.GetAll.GetAllShopAddresses
{
    public class GetAllShopAddressesQueryHandler : IRequestHandler<GetAllShopAddressesQueryRequest, GetAllShopAddressesQueryResponse>
    {
        readonly IShopService _service;

        public GetAllShopAddressesQueryHandler(IShopService service)
        {
            _service = service;
        }

        public async Task<GetAllShopAddressesQueryResponse> Handle(GetAllShopAddressesQueryRequest request, CancellationToken cancellationToken)
        {
            var dtos = await _service.GetAllShopAddressesAsync(request.Page, request.Size, request.ShopId);

            return new GetAllShopAddressesQueryResponse
            {
                Datas = dtos,
                TotalCount = dtos.Count()
            };
        }
    }
}
