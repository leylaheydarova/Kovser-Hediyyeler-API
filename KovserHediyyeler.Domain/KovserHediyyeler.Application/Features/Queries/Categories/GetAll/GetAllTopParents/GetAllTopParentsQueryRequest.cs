using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Categories.GetAll.GetAllAbstractParents
{
    public class GetAllTopParentsQueryRequest : GetAllQueryRequest, IRequest<GetAllTopParentsQueryResponse>
    {
    }
}
