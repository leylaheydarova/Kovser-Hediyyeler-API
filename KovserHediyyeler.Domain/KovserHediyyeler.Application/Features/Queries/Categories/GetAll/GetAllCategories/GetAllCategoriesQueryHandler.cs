using KovserHediyyeler.Application.Abstractions;
using MediatR;


namespace KovserHedieyyeler.Application.Features.Queries.Categories.GetAll.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQueryRequest, GetAllCategoriesQueryResponse>
    {
        readonly ICategoryService _service;

        public GetAllCategoriesQueryHandler(ICategoryService service)
        {
            _service = service;
        }

        public async Task<GetAllCategoriesQueryResponse> Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var dtos = await _service.GetAllCategoriesAsync();

            return new GetAllCategoriesQueryResponse
            {
                Datas = dtos,
                TotalCount = dtos.Count()
            };
        }
    }
}
