using MediatR;


namespace KovserHedieyyeler.Application.Features.Queries.Categories.GetSingle
{
    public class GetSingleCategoryQueryRequest:GetSingleQueryRequest, IRequest<GetSingleCategoryQueryResponse>
    {
    }
}
