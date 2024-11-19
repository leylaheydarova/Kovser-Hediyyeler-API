using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Products.GetAll.GetAllProductProperties
{
    public class GetAllProductPropertiesQueryHandler : IRequestHandler<GetAllProductPropertiesQueryRequest, GetAllProductPropertiesQueryResponse>
    {
        readonly IProductService _service;

        public GetAllProductPropertiesQueryHandler(IProductService service)
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
