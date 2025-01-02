using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.Products.GetAll.GetAllColors
{
    public class GetAllColorsQueryHandler : IRequestHandler<GetAllColorsQueryRequest, GetAllColorsQueryResponse>
    {
        readonly IProductService _service;

        public GetAllColorsQueryHandler(IProductService service)
        {
            _service = service;
        }

        public async Task<GetAllColorsQueryResponse> Handle(GetAllColorsQueryRequest request, CancellationToken cancellationToken)
        {
            var dtos = await _service.GetAllProductColorsAsync(request.Page, request.Size, request.ProductId);
            return new GetAllColorsQueryResponse
            {
                Datas = dtos,
                TotalCount = dtos.Count()
            };
        }
    }
}
