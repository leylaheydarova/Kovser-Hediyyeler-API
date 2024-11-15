using KovserHedieyyeler.Application.DTOs.Categories;
using KovserHediyyeler.Application.Repositories.Categories;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KovserHedieyyeler.Application.Features.Queries.Categories.GetAll.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQueryRequest, GetAllCategoriesQueryResponse>
    {
        readonly ICategoryReadRepository _repository;

        public GetAllCategoriesQueryHandler(ICategoryReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAllCategoriesQueryResponse> Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
        {

            var query = _repository.GetAllWhere(x => !x.isDeleted, false);
            int totalCount = query.Count();
            List<CategoryGetDto> dtos = new List<CategoryGetDto>();
            dtos = await query.Select(x => new CategoryGetDto
            {
                Id = x.ID.ToString(),
                Name = x.Name,
                ParentID = x.ParentId.ToString(),
                ParentCategoryName = x.ParentId != null ? x.ParentCategory.Name : "Ana kateqoriya"
            }).ToListAsync();
            return new GetAllCategoriesQueryResponse
            {
                Datas = dtos,
                TotalCount = totalCount
            };
        }
    }
}
