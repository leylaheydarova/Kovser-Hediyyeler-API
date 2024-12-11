using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.Search
{
    public class SearchQueryHandler : IRequestHandler<SearchQueryRequest, SearchQueryResponse>
    {
        readonly ISearchService _service;

        public SearchQueryHandler(ISearchService service)
        {
            _service = service;
        }

        public async Task<SearchQueryResponse> Handle(SearchQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await _service.SearchProducts(request.Query);
            return new SearchQueryResponse
            {
                Products = products,
            };
        }
    }
}
