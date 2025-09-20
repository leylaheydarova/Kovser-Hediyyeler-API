
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Products.GetAll.GetAllProductImages
{
    public class GetAllProductImagesQueryRequest : GetAllQueryRequest, IRequest<GetAllProductImagesQueryResponse>
    {
        public Guid ProductId { get; set; }
    }
}
