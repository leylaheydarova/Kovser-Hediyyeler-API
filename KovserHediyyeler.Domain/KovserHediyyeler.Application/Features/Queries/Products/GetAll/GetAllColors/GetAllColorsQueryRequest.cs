using KovserHedieyyeler.Application.Features.Queries;
using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.Products.GetAll.GetAllColors
{
    public class GetAllColorsQueryRequest:GetAllQueryRequest, IRequest<GetAllColorsQueryResponse>
    {
        public string ProductId { get; set; }
    }
}
