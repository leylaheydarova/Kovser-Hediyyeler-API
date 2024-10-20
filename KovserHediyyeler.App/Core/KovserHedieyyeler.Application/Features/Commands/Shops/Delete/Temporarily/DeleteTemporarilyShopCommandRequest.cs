
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Shops.Delete.Temporarily
{
    public class DeleteTemporarilyShopCommandRequest:DeleteCommandRequest, IRequest<DeleteTemporarilyShopCommandResponse>
    {
    }
}
