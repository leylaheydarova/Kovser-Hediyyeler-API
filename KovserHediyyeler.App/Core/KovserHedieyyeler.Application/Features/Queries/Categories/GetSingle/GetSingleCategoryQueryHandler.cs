using AutoMapper;
using KovserHedieyyeler.Application.DTOs.Categories;
using KovserHedieyyeler.Application.Exceptions;
using KovserHedieyyeler.Application.Repositories.Abstractions.Categories;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Categories.GetSingle
{
    public class GetSingleCategoryQueryHandler : IRequestHandler<GetSingleCategoryQueryRequest, GetSingleCategoryQueryResponse>
    {
        readonly ICategoryReadRepository _repository;
        readonly IMapper _mapper;

        public GetSingleCategoryQueryHandler(ICategoryReadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetSingleCategoryQueryResponse> Handle(GetSingleCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            Category category = await _repository.GetWhereAsync(x => !x.isDeleted && x.ID.ToString() == request.Id, false);
            if(category == null)
            {
                throw new CategoryNotFoundException();
            }
            CategoryGetDto dto = _mapper.Map<CategoryGetDto>(category);
            return new GetSingleCategoryQueryResponse
            {
                Dto = dto
            };
        }
    }
}
