using KovserHedieyyeler.Application.Features.Commands;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Categories.Delete.Permanently.OnlyBase
{
    public class RemovePermanentlyCategoryCommandRequest : DeleteCommandRequest, IRequest<RemovePermanentlyCategoryCommandResponse>
    {
    }
}
