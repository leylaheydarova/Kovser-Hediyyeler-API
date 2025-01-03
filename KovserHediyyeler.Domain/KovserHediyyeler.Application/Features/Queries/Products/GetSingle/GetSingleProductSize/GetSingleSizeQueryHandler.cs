using KovserHediyyeler.Application.Abstractions.Products;
using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.Products.GetSingle.GetSingleProductSize
{
    public class GetSingleSizeQueryHandler : IRequestHandler<GetSingleSizeQueryRequest, GetSingleSizeQueryResponse>
    {
        readonly IProductGetSingleService _service;

        public GetSingleSizeQueryHandler(IProductGetSingleService service)
        {
            _service = service;
        }

        public async Task<GetSingleSizeQueryResponse> Handle(GetSingleSizeQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = await _service.GetSingleProductSizeAsync(request.Id);
            return new GetSingleSizeQueryResponse
            {
                Dto = dto
            };
        }
    }
}
