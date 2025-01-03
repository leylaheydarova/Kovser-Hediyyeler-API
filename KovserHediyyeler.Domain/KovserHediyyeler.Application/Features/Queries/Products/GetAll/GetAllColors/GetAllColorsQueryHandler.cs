using KovserHediyyeler.Application.Abstractions.Products;
using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.Products.GetAll.GetAllColors
{
    public class GetAllColorsQueryHandler : IRequestHandler<GetAllColorsQueryRequest, GetAllColorsQueryResponse>
    {
        readonly IProductGetAllService _service;

        public GetAllColorsQueryHandler(IProductGetAllService service)
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
