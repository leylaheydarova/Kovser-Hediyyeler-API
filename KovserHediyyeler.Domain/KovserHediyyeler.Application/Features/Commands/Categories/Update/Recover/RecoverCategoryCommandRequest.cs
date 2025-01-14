using KovserHedieyyeler.Application.Features.Commands;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Categories.Update.Recover
{
    public class RecoverCategoryCommandRequest : RecoverCommandRequest, IRequest<RecoverCategoryCommandResponse>
    {
    }
}
