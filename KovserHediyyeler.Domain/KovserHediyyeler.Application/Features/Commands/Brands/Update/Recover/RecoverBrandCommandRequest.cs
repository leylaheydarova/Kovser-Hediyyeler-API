using KovserHedieyyeler.Application.Features.Commands;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Brands.Update.Recover
{
    public class RecoverCategoryRequest : RecoverCommandRequest, IRequest<RecoverBrandCommandResponse>
    {
    }
}
