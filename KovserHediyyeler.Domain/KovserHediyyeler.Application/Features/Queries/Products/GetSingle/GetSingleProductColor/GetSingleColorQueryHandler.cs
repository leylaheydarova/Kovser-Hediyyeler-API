using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.Products.GetSingle.GetSingleProductColor
{
    public class GetSingleColorQueryHandler : IRequestHandler<GetSingleColorQueryRequest, GetSingleColorQueryResponse>
    {
        readonly IProductService _service;

        public GetSingleColorQueryHandler(IProductService service)
        {
            _service = service;
        }

        public async Task<GetSingleColorQueryResponse> Handle(GetSingleColorQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = await _service.GetSingleProductColorAsync(request.Id);
            return new GetSingleColorQueryResponse
            {
                Dto = dto
            };
        }
    }
}
