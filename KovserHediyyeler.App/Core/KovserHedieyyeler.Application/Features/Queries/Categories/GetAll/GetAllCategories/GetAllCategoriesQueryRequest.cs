using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Categories.GetAll.GetAllCategories
{
    public class GetAllCategoriesQueryRequest : GetAllQueryRequest, IRequest<GetAllCategoriesQueryResponse>
    {

    }
}
