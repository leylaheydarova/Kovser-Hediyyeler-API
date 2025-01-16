using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.Categories.GetAll.GetAllChilds
{
    public class GetAllChildsQueryHandler : IRequestHandler<GetAllChildsQueryRequest, GetAllChildsQueryResponse>
    {
        readonly ICategoryService _service;

        public GetAllChildsQueryHandler(ICategoryService service)
        {
            _service = service;
        }

        public async Task<GetAllChildsQueryResponse> Handle(GetAllChildsQueryRequest request, CancellationToken cancellationToken)
        {
            var dtos = await _service.GetAllCategoryChildsAsync(request.Page, request.Size, request.ParentId);
            return new GetAllChildsQueryResponse
            {
                Datas = dtos,
                TotalCount = dtos.Count()
            };
        }
    }
}
