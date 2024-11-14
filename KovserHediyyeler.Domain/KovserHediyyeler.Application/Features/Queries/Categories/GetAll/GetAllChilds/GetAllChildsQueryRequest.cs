using KovserHedieyyeler.Application.Features.Queries;
using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.Categories.GetAll.GetAllChilds
{
    public class GetAllChildsQueryRequest : GetAllQueryRequest, IRequest<GetAllChildsQueryResponse>
    {
        public string ParentId { get; set; }
    }
}
