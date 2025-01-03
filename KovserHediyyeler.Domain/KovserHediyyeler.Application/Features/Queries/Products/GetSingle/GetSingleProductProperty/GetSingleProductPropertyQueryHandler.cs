using KovserHediyyeler.Application.Abstractions.Products;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Products.GetSingle.GetSingleProductProperty
{
    public class GetSingleProductPropertyQueryHandler : IRequestHandler<GetSingleProductPropertyQueryRequest, GetSingleProductPropertyQueryResponse>
    {
        readonly IProductGetSingleService _service;

        public GetSingleProductPropertyQueryHandler(IProductGetSingleService service)
        {
            _service = service;
        }

        public async Task<GetSingleProductPropertyQueryResponse> Handle(GetSingleProductPropertyQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = await _service.GetSingleProductPropertyAsync(request.Id);

            return new GetSingleProductPropertyQueryResponse
            {
                Dto = dto
            };
        }
    }
}
