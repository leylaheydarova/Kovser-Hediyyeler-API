using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Products.GetAll.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, GetAllProductsQueryResponse>
    {
        readonly IProductService _service;

        public GetAllProductsQueryHandler(IProductService service)
        {
            _service = service;
        }

        public async Task<GetAllProductsQueryResponse> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var dtos = await _service.GetAllProductsAsync(request.Page, request.Size);

            return new GetAllProductsQueryResponse
            {
                Datas = dtos,
                TotalCount = dtos.Count,
            };
        }

    }
}
