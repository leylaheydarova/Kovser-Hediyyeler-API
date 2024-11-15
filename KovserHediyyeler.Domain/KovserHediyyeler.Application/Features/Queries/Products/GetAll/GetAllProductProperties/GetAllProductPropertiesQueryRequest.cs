using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Products.GetAll.GetAllProductProperties
{
    public class GetAllProductPropertiesQueryRequest:GetAllQueryRequest, IRequest<GetAllProductPropertiesQueryResponse>
    {
        public string ProductId { get; set; }
    }
}
