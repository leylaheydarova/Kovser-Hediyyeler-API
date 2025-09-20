using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Departments.GetAll.GetAllSocialMedias
{
    public class GetAllSocialMediasQueryRequest : IRequest<GetAllSocialMediasQueryResponse>
    {
        public Guid DepartmentId { get; set; }
    }
}
