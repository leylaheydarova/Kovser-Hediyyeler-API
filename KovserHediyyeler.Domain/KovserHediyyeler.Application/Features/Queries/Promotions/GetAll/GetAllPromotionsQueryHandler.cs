using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Promotions.GetAll
{
    public class GetAllPromotionsQueryHandler : IRequestHandler<GetAllPromotionsQueryRequest, GetAllPromotionsQueryResponse>
    {
        readonly IPromotionService _service;

        public GetAllPromotionsQueryHandler(IPromotionService service)
        {
            _service = service;
        }

        public async Task<GetAllPromotionsQueryResponse> Handle(GetAllPromotionsQueryRequest request, CancellationToken cancellationToken)
        {
            var dtos = await _service.GetAllAsync(request.Page, request.Size);

            return new GetAllPromotionsQueryResponse
            {
                Datas = dtos,
                TotalCount = dtos.Count
            };
        }
    }
}
