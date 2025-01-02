using KovserHedieyyeler.Application.Features.Commands;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Products.Delete.Permanently.RemoveColor
{
    public class RemoveColorCommandRequest:DeleteCommandRequest, IRequest<RemoveColorCommandResponse>
    {
    }
}
