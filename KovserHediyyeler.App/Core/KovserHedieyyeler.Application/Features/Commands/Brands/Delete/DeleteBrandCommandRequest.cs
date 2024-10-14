using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Brands.Delete
{
    public class DeleteBrandCommandRequest:DeleteCommandRequest, IRequest<DeleteBrandCommandResponse>
    {
    }
}
