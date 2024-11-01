

using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Departments.Delete.Permanently.RemoveSocialMedia
{
    public class RemoveSocialMediaCommandRequest:DeleteCommandRequest, IRequest<RemoveSocialMediaCommandResponse>
    {
    }
}
