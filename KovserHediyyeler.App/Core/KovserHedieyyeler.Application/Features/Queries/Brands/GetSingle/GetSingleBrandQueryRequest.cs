using MediatR;


namespace KovserHedieyyeler.Application.Features.Queries.Brands.GetSingle
{
    public class GetSingleBrandQueryRequest:GetSingleQueryRequest, IRequest<GetSingleBrandQueryResponse>
    {
        
    }
}
