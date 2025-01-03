using KovserHediyyeler.Application.Abstractions.Products;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Products.GetAll.GetAllProductProperties
{
    public class GetAllProductPropertiesQueryHandler : IRequestHandler<GetAllProductPropertiesQueryRequest, GetAllProductPropertiesQueryResponse>
    {
        readonly IProductGetAllService _service;

        public GetAllProductPropertiesQueryHandler(IProductGetAllService service)
        {
            _service = service;
        }


        public async Task<GetAllProductPropertiesQueryResponse> Handle(GetAllProductPropertiesQueryRequest request, CancellationToken cancellationToken)
        {
            var dtos = await _service.GetAllProductPropertiesAsync(request.Page, request.Size, request.ProductId);
            return new GetAllProductPropertiesQueryResponse
            {
                Datas = dtos,
                TotalCount = dtos.Count
            };
        }
    }
}
