using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Delete.Permanently.RemoveImage
{
    public class RemoveProductImageCommandRequest:DeleteCommandRequest, IRequest<RemoveProductImageCommandResponse>
    {
    }
}
