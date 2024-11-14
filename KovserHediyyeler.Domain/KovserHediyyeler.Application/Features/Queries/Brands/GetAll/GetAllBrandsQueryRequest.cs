using MediatR;


namespace KovserHedieyyeler.Application.Features.Queries.Brands.GetAll
{
    public class GetAllBrandsQueryRequest : GetAllQueryRequest, IRequest<GetAllBrandsQueryResponse>
    {
    }
}
