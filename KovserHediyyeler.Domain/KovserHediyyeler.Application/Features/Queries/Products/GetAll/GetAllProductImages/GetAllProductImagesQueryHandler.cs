using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Products.GetAll.GetAllProductImages
{
    public class GetAllProductImagesQueryHandler : IRequestHandler<GetAllProductImagesQueryRequest, GetAllProductImagesQueryResponse>
    {
        readonly IProductService _service;

        public GetAllProductImagesQueryHandler(IProductService service)
        {
            _service = service;
        }

        public async Task<GetAllProductImagesQueryResponse> Handle(GetAllProductImagesQueryRequest request, CancellationToken cancellationToken)
        {
            var dtos = await _service.GetAllProductImagesAsync(request.Page, request.Size, request.ProductId);

            return new GetAllProductImagesQueryResponse
            {
                Datas = dtos,
                TotalCount = dtos.Count
            };
        }
    }
}
