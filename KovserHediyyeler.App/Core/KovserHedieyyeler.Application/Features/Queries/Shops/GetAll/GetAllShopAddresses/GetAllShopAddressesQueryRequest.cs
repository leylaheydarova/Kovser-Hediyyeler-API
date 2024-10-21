using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Shops.GetAll.GetAllShopAddresses
{
    public class GetAllShopAddressesQueryRequest:GetAllQueryRequest, IRequest<GetAllShopAddressesQueryResponse>
    {
        public string ShopId { get; set; }
    }
}
