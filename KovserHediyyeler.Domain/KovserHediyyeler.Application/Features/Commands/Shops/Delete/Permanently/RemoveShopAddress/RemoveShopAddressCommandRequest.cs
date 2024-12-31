using KovserHediyyeler.Application.Features.Commands.Shops.Delete.Permanently.RemoveShopAddress;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Shops.Delete.Permanently.RemoveShopAddress
{
    public class RemoveShopAddressCommandRequest : DeleteCommandRequest, IRequest<RemoveShopAddressCommandResponse>
    {
    }
}
