using KovserHedieyyeler.Application.DTOs.Department;
using KovserHedieyyeler.Application.DTOs.SocialMedias;
using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Departments;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Departments.GetSingle
{
    public class GetSingleDepartmentQueryHandler : IRequestHandler<GetSingleDepartmentQueryRequest, GetSingleDepartmentQueryResponse>
    {
        readonly IDepartmentReadRepository _repository;

        public GetSingleDepartmentQueryHandler(IDepartmentReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetSingleDepartmentQueryResponse> Handle(GetSingleDepartmentQueryRequest request, CancellationToken cancellationToken)
        {
            Department department = await _repository.GetWhereAsync(x => !x.isDeleted && x.ID == Guid.Parse(request.Id), false, "SocialMedias");
            if (department == null)
            {
                throw new DepartmentNotFoundException();
            }
            DepartmentGetSingleDto dto = new DepartmentGetSingleDto
            {
                Id = department.ID.ToString(),
                Name = department.Name,
                Description = department.Description,
                LogoImage = department.LogoImage,
                LogoImageURL = department.LogoImageURL,
                Phone = department.Phone,
                SocialMedias = department.SocialMedias.Select(socialMedia => new SocialMediaGetDto
                {
                    Id = socialMedia.ID.ToString(),
                    Name = socialMedia.Name,
                    NickName = socialMedia.NickName,
                    URL = socialMedia.URL,
                    DepartmenName = socialMedia.Department.Name
                }).ToList()
            };


            return new GetSingleDepartmentQueryResponse
            {
                Dto = dto
            };
        }
    }
}
