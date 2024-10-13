using KovserHedieyyeler.Application.RequestParameter;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Categories.GetAll
{
    public class GetAllCategoriesQueryRequest:GetAllQueryRequest,IRequest<GetAllCategoriesQueryResponse>
    {
        
    }
}
