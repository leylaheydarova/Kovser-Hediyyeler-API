using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Recover
{
    public class RecoverProductCommandRequest:RecoverCommandRequest, IRequest<RecoverProductCommandResponse>
    {
    }
}
