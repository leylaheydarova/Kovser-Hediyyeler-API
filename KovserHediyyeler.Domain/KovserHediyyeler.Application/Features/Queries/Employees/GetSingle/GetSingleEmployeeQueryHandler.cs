using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Employees.GetSingle
{
    public class GetSingleEmployeeQueryHandler : IRequestHandler<GetSingleEmployeeQueryRequest, GetSingleEmployeeQueryResponse>
    {
        readonly IEmployeeService _service;

        public GetSingleEmployeeQueryHandler(IEmployeeService service)
        {
            _service = service;
        }

        public async Task<GetSingleEmployeeQueryResponse> Handle(GetSingleEmployeeQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = await _service.GetSingleEmployeeAsync(request.Id);

            return new GetSingleEmployeeQueryResponse
            {
                Dto = dto
            };
        }
    }
}


