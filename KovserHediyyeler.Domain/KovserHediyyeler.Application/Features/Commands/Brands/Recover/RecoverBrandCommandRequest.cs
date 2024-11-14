using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Brands.Recover
{
    public class RecoverCategoryRequest:RecoverCommandRequest, IRequest<RecoverBrandCommandResponse>
    {
    }
}
