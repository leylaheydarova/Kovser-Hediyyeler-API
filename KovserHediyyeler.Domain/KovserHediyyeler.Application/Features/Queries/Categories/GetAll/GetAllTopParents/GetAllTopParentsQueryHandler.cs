using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Categories.GetAll.GetAllAbstractParents
{
    public class GetAllTopParentsQueryHandler : IRequestHandler<GetAllTopParentsQueryRequest, GetAllTopParentsQueryResponse>
    {
        readonly ICategoryService _service;

        public GetAllTopParentsQueryHandler(ICategoryService service)
        {
            _service = service;
        }

        public async Task<GetAllTopParentsQueryResponse> Handle(GetAllTopParentsQueryRequest request, CancellationToken cancellationToken)
        {
            var dtos = await _service.GetAllTopCategoriesAsync(request.Page, request.Size);
            return new GetAllTopParentsQueryResponse
            {
                Datas = dtos,
                TotalCount = dtos.Count()
            };
        }
    }
}
