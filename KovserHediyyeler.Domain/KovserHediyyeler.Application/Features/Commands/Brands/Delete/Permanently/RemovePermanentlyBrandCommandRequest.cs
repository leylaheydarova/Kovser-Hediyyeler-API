using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Brands.Delete.Permanently
{
    public class RemovePermanentlyBrandCommandRequest:DeleteCommandRequest, IRequest<RemovePermanentlyBrandCommandResponse>
    {
    }
}
