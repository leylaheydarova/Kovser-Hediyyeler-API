using KovserHedieyyeler.Application.Features.Commands;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Categories.Delete.Permanently.WithItsChild
{
    public class RemoveCategoryWithChildCommandRequest : DeleteCommandRequest, IRequest<RemoveCategoryWithChildCommandResponse>
    {
    }
}
