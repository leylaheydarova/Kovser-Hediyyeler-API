using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.Search
{
    public class SearchQueryRequest : IRequest<SearchQueryResponse>
    {
        public string Query { get; set; }
    }
}
