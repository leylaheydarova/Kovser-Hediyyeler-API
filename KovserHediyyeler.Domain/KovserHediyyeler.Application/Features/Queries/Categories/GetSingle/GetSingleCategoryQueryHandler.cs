using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Categories.GetSingle
{
    public class GetSingleCategoryQueryHandler : IRequestHandler<GetSingleCategoryQueryRequest, GetSingleCategoryQueryResponse>
    {
        readonly ICategoryService _service;

        public GetSingleCategoryQueryHandler(ICategoryService service)
        {
            _service = service;
        }

        public async Task<GetSingleCategoryQueryResponse> Handle(GetSingleCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = await _service.GetSingleCategoryAsync(request.Id);

            return new GetSingleCategoryQueryResponse
            {
                Dto = dto
            };
        }
    }
}
