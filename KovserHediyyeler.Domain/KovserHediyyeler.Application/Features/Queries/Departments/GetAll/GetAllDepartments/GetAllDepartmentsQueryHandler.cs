using KovserHediyyeler.Application.Abstractions;
using MediatR;


namespace KovserHedieyyeler.Application.Features.Queries.Departments.GetAll.GetAllDepartments
{
    public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQueryRequest, GetAllDepartmentsQueryResponse>
    {
        readonly IDepartmentService _service;

        public GetAllDepartmentsQueryHandler(IDepartmentService service)
        {
            _service = service;
        }

        public async Task<GetAllDepartmentsQueryResponse> Handle(GetAllDepartmentsQueryRequest request, CancellationToken cancellationToken)
        {
            var dtos = await _service.GetAllDepartments(request.Page, request.Size);
            return new GetAllDepartmentsQueryResponse
            {
                Datas = dtos,
                TotalCount = dtos.Count()
            };
        }
    }
}
