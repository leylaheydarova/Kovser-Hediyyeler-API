using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.Products.GetAll.GetAllSizes
{
    public class GetAllSizesCommandHandler : IRequestHandler<GetAllSizesCommandRequest, GetAllSizesCommandResponse>
    {
        readonly IProductService _service;

        public GetAllSizesCommandHandler(IProductService service)
        {
            _service = service;
        }

        public async Task<GetAllSizesCommandResponse> Handle(GetAllSizesCommandRequest request, CancellationToken cancellationToken)
        {
            var dtos = await _service.GetAllProductSizesAsync(request.Page, request.Size, request.ProductId);
            return new GetAllSizesCommandResponse
            {
                Datas = dtos,
                TotalCount = dtos.Count()
            };
        }
    }
}
