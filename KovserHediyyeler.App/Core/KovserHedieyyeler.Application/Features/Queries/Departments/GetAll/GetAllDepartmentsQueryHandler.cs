using KovserHedieyyeler.Application.DTOs.Department;
using KovserHedieyyeler.Application.Repositories.Abstractions.Departments;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KovserHedieyyeler.Application.Features.Queries.Departments.GetAll
{
    public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQueryRequest, GetAllDepartmentsQueryResponse>
    {
        readonly IDepartmentReadRepository _repository;

        public GetAllDepartmentsQueryHandler(IDepartmentReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAllDepartmentsQueryResponse> Handle(GetAllDepartmentsQueryRequest request, CancellationToken cancellationToken)
        {
            var query = _repository.GetAllWhere(x => !x.isDeleted, false);
            int totalCount = query.Count();
            List<DepartmentGetAllDto> dtos = new List<DepartmentGetAllDto>();
            dtos = await query.Skip(request.Page * request.Size)
                .Take(request.Size)
                .Select(x => new DepartmentGetAllDto
                {
                    Id = x.ID.ToString(),
                    Name = x.Name,
                    Description = x.Description,
                    LogoImage = x.LogoImage,
                    LogoImageURL = x.LogoImageURL
                }).ToListAsync();
            return new GetAllDepartmentsQueryResponse
            {
                Dtos = dtos,
                TotalCount = totalCount
            };
        }
    }
}
