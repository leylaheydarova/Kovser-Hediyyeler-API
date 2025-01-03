using KovserHediyyeler.Application.Abstractions.Products;
using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.Products.GetAll.GetAllCategoryProducts
{
    public class GetAllFilteredProductsQueryHandler : IRequestHandler<GetAllFilteredProductsQueryRequest, GetAllFilteredProductsQueryResponse>
    {
        readonly IProductGetAllService _service;

        public GetAllFilteredProductsQueryHandler(IProductGetAllService service)
        {
            _service = service;
        }

        public async Task<GetAllFilteredProductsQueryResponse> Handle(GetAllFilteredProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var dtos = await _service.GetAllFilteredProductsAsync(request.Page, request.Size, request.BrandIdOrCategoryIdOrDepartmentIdOrShopId);

            return new GetAllFilteredProductsQueryResponse
            {
                Datas = dtos,
                TotalCount = dtos.Count
            };
        }
    }
}
