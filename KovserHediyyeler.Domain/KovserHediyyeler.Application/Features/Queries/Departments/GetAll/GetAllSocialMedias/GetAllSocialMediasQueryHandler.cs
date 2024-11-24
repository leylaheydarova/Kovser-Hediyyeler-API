using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Departments.GetAll.GetAllSocialMedias
{
    public class GetAllSocialMediasQueryHandler : IRequestHandler<GetAllSocialMediasQueryRequest, GetAllSocialMediasQueryResponse>
    {
        readonly IDepartmentService _service;

        public GetAllSocialMediasQueryHandler(IDepartmentService service)
        {
            _service = service;
        }

        public async Task<GetAllSocialMediasQueryResponse> Handle(GetAllSocialMediasQueryRequest request, CancellationToken cancellationToken)
        {

            var dtos = await _service.GetAllDepartmentSocialMedias(request.DepartmentId);
            return new GetAllSocialMediasQueryResponse
            {
                Datas = dtos,
                TotalCount = dtos.Count
            };
        }
    }
}
