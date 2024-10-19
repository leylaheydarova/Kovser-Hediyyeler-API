using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Brands.Recover
{
    public class RecoverBrandCommandRequest:RecoverCommandRequest, IRequest<RecoverBrandCommandResponse>
    {
    }
}
