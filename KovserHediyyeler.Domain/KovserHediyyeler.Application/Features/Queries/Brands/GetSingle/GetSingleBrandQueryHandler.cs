using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Brands.GetSingle
{
    public class GetSingleBrandQueryHandler : IRequestHandler<GetSingleBrandQueryRequest, GetSingleBrandQueryResponse>
    {
        readonly IBrandService _service;

        public GetSingleBrandQueryHandler(IBrandService service)
        {
            _service = service;
        }

        public async Task<GetSingleBrandQueryResponse> Handle(GetSingleBrandQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = await _service.GetSingleAsync(request.Id);

            return new GetSingleBrandQueryResponse
            {
                Dto = dto
            };
        }
    }
}
