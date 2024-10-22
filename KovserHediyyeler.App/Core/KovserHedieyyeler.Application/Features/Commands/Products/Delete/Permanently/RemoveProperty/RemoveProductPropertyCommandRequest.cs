using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Delete.Permanently.RemoveProperty
{
    public class RemoveProductPropertyCommandRequest:DeleteCommandRequest, IRequest<RemoveProductPropertyCommandResponse>
    {
    }
}
