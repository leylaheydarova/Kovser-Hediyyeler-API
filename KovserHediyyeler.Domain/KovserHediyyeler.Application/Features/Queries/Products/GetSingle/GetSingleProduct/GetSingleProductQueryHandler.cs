using KovserHediyyeler.Application.Abstractions.Products;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Products.GetSingle.GetSingleProduct
{
    public class GetSingleProductQueryHandler : IRequestHandler<GetSingleProductQueryRequest, GetSingleProductQueryResponse>
    {
        readonly IProductGetSingleService _service;

        public GetSingleProductQueryHandler(IProductGetSingleService service)
        {
            _service = service;
        }

        public async Task<GetSingleProductQueryResponse> Handle(GetSingleProductQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = await _service.GetSingleProductAsync(request.Id);
            return new GetSingleProductQueryResponse
            {
                Dto = dto
            };
        }
    }
}
