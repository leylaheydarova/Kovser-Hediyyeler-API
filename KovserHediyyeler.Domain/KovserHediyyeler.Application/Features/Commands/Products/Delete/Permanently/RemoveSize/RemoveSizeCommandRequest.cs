using KovserHedieyyeler.Application.Features.Commands;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Products.Delete.Permanently.RemoveSize
{
    public class RemoveSizeCommandRequest:DeleteCommandRequest, IRequest<RemoveSizeCommandResponse>
    {
    }
}
