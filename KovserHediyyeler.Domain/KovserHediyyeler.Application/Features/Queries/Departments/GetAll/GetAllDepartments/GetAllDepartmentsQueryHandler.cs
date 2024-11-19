using KovserHedieyyeler.Application.DTOs.Department;
using KovserHediyyeler.Application.Constants;
using KovserHediyyeler.Application.Repositories.Departments;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KovserHedieyyeler.Application.Features.Queries.Departments.GetAll.GetAllDepartments
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
            var query = _repository.GetAllWhere(x => !x.isDeleted, false, "SocialMedias");
            int totalCount = query.Count();
            List<DepartmentGetAllDto> dtos = new List<DepartmentGetAllDto>();
            dtos = await query.Skip(request.Page * request.Size)
                .Take(request.Size)
                .Select(x => new DepartmentGetAllDto
                {
                    Id = x.ID.ToString(),
                    Name = x.Name,
                    Description = x.Description,
                    LogoImage = x.LogoImage != null ? x.LogoImage : ConstantPaths.DefaultImage,
                    LogoImageURL = x.LogoImage != null ? x.LogoImageURL : ConstantPaths.DefaultImageURL
                }).ToListAsync();
            return new GetAllDepartmentsQueryResponse
            {
                Datas = dtos,
                TotalCount = totalCount
            };
        }
    }
}
