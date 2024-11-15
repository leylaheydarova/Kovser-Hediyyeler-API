using KovserHedieyyeler.Application.DTOs.SocialMedias;
using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.SocialMedias;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KovserHedieyyeler.Application.Features.Queries.Departments.GetAll.GetAllSocialMedias
{
    public class GetAllSocialMediasQueryHandler : IRequestHandler<GetAllSocialMediasQueryRequest, GetAllSocialMediasQueryResponse>
    {
        readonly ISocialMediaReadRepository _repository;

        public GetAllSocialMediasQueryHandler(ISocialMediaReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAllSocialMediasQueryResponse> Handle(GetAllSocialMediasQueryRequest request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.DepartmentId, out var departmentId))
            {
                throw new DepartmentNotFoundException();
            }
            var query = _repository.GetAllWhere(x => !x.isDeleted && x.DepartmentID == departmentId, false);
            query = query.Include(sm => sm.Department);
            int totalCount = query.Count();
            if (!query.Any()) throw new DepartmentNotFoundException();
            List<SocialMediaGetDto> dtos = new List<SocialMediaGetDto>();
            dtos = await query.Select(x => new SocialMediaGetDto
            {
                Id = x.ID.ToString(),
                Name = x.Name,
                NickName = x.NickName,
                URL = x.URL,
                DepartmenName = x.Department.Name
            }).ToListAsync();

            return new GetAllSocialMediasQueryResponse
            {
                Datas = dtos,
                TotalCount = totalCount
            };
        }
    }
}
