using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Delete.Temporarily
{
    public class DeleteTemporarilyProductCommandRequest:DeleteCommandRequest, IRequest<DeleteTemporarilyProductCommandResponse>
    {
    }
}
