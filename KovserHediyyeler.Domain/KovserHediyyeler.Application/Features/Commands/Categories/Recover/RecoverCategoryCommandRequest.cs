using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Categories.Recover
{
    public class RecoverCategoryCommandRequest:RecoverCommandRequest, IRequest<RecoverCategoryCommandResponse>
    {
    }
}
