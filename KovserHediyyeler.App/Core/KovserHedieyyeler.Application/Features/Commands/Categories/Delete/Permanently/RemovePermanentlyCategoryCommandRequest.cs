using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Categories.Delete.Permanently
{
    public class RemovePermanentlyCategoryCommandRequest:DeleteCommandRequest, IRequest<RemovePermanentlyCategoryCommandResponse>
    {
    }
}
