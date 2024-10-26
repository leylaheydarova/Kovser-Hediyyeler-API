using KovserHedieyyeler.Application.DTOs.Categories;
using KovserHedieyyeler.Application.Repositories.Interfaces.Categories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
