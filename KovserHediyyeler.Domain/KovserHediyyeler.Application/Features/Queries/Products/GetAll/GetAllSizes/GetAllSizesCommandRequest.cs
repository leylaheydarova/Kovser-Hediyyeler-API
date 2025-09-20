using KovserHedieyyeler.Application.Features.Queries;
using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.Products.GetAll.GetAllSizes
{
    public class GetAllSizesCommandRequest : GetAllQueryRequest, IRequest<GetAllSizesCommandResponse>
    {
        public Guid ProductId { get; set; }
    }
}
