using KovserHedieyyeler.Application.DTOs.Categories;
using KovserHediyyeler.Application.Repositories.Categories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KovserHedieyyeler.Application.Features.Queries.Categories.GetAll.GetAllAbstractParents
{
    public class GetAllTopParentsQueryHandler : IRequestHandler<GetAllTopParentsQueryRequest, GetAllTopParentsQueryResponse>
    {
        readonly ICategoryReadRepository _repository;

        public GetAllTopParentsQueryHandler(ICategoryReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAllTopParentsQueryResponse> Handle(GetAllTopParentsQueryRequest request, CancellationToken cancellationToken)
        {
            var query = _repository.GetAllWhere(x => !x.isDeleted && x.ParentId == null, false);
            int totalCount = query.Count();
            List<CategoryGetDto> dtos = new List<CategoryGetDto>();
            dtos = await query.Skip(request.Page * request.Size)
                .Take(request.Size)
                .Select(x => new CategoryGetDto
                {
                    Id = x.ID.ToString(),
                    Name = x.Name,
                    ParentCategoryName = x.ParentId != null ? x.ParentCategory.Name : "Ana kateqoriya"
                }).ToListAsync();
            return new GetAllTopParentsQueryResponse
            {
                Datas = dtos,
                TotalCount = totalCount
            };
        }
    }
}
