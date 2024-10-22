using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Delete.Permanently.RemoveProducts
{
    public class RemovePermanentlyProductCommandRequest:DeleteCommandRequest, IRequest<RemovePermanentlyProductCommandResponse>
    {
    }
}
