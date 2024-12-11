using KovserHedieyyeler.Application.DTOs.Categories;
using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Categories;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Categories.GetSingle
{
    public class GetSingleCategoryQueryHandler : IRequestHandler<GetSingleCategoryQueryRequest, GetSingleCategoryQueryResponse>
    {
        readonly ICategoryReadRepository _repository;

        public GetSingleCategoryQueryHandler(ICategoryReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetSingleCategoryQueryResponse> Handle(GetSingleCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            Category category = await _repository.GetWhereAsync(x => !x.isDeleted && x.ID.ToString() == request.Id, false, "ParentCategory");
            if (category == null)
            {
                throw new NotFoundException("kateqoriya");
            }
            CategoryGetDto dto = new CategoryGetDto
            {
                Id = category.ID.ToString(),
                Name = category.Name,
                ParentID = category.ParentId.ToString(),
                ParentCategoryName = category.ParentId != null ? category.ParentCategory.Name : "Ana kateqoriya"
            };
            return new GetSingleCategoryQueryResponse
            {
                Dto = dto
            };
        }
    }
}
