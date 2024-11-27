using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Promotions.GetSingle
{
    public class GetSinglePromotionQueryHandler : IRequestHandler<GetSinglePromotionQueryRequest, GetSinglePromotionQueryResponse>
    {
        readonly IPromotionService _service;

        public GetSinglePromotionQueryHandler(IPromotionService service)
        {
            _service = service;
        }

        public async Task<GetSinglePromotionQueryResponse> Handle(GetSinglePromotionQueryRequest request, CancellationToken cancellationToken)
        {

            var dto = await _service.GetSingleAsync(request.Id);

            return new GetSinglePromotionQueryResponse
            {
                Dto = dto
            };
        }
    }
}
//todo: bir mehuslun endirime dusub dusmemesini yoxlayan bir metod yaz