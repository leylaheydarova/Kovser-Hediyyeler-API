using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Departments.GetSingle
{
    public class GetSingleDepartmentQueryHandler : IRequestHandler<GetSingleDepartmentQueryRequest, GetSingleDepartmentQueryResponse>
    {
        readonly IDepartmentService _service;

        public GetSingleDepartmentQueryHandler(IDepartmentService service)
        {
            _service = service;
        }

        public async Task<GetSingleDepartmentQueryResponse> Handle(GetSingleDepartmentQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = await _service.GetSingleDepartment(request.Id);


            return new GetSingleDepartmentQueryResponse
            {
                Dto = dto
            };
        }
    }
}
