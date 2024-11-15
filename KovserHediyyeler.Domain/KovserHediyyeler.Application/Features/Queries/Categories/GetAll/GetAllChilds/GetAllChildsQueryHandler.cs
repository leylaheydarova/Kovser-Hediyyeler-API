using KovserHedieyyeler.Application.DTOs.Categories;
using KovserHediyyeler.Application.Repositories.Categories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KovserHediyyeler.Application.Features.Queries.Categories.GetAll.GetAllChilds
{
    public class GetAllChildsQueryHandler : IRequestHandler<GetAllChildsQueryRequest, GetAllChildsQueryResponse>
    {
        readonly ICategoryReadRepository _repository;

        public GetAllChildsQueryHandler(ICategoryReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAllChildsQueryResponse> Handle(GetAllChildsQueryRequest request, CancellationToken cancellationToken)
        {
            var query = _repository.GetAllWhere(c => c.ParentId.ToString() == request.ParentId && !c.isDeleted, false, "ParentCategory");
            List<CategoryGetDto> dtos = new List<CategoryGetDto>();
            dtos = await query
                .Skip(request.Page * request.Size)
                .Take(request.Size)
                .Select(c => new CategoryGetDto
                {
                    Id = c.ID.ToString(),
                    Name = c.Name,
                    ParentID = c.ParentId.ToString(),
                    ParentCategoryName = c.ParentCategory.Name
                }).ToListAsync();
            return new GetAllChildsQueryResponse
            {
                Datas = dtos,
                TotalCount = query.Count()
            };
        }
    }
}
