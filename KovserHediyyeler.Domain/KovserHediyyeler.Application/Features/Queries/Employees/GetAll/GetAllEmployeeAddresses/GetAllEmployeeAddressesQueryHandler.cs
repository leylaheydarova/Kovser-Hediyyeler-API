using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Employees.GetAll.GetAllEmployeeAddresses
{
    public class GetAllEmployeeAddressesQueryHandler : IRequestHandler<GetAllEmployeeAddressesQueryRequest, GetAllEmployeeAddressesQueryResponse>
    {
        readonly IEmployeeService _service;

        public GetAllEmployeeAddressesQueryHandler(IEmployeeService service)
        {
            _service = service;
        }

        public async Task<GetAllEmployeeAddressesQueryResponse> Handle(GetAllEmployeeAddressesQueryRequest request, CancellationToken cancellationToken)
        {
            var dtos = await _service.GetAllEmployeeAddressesAsync(request.Page, request.Size, request.EmployeeId);

            return new GetAllEmployeeAddressesQueryResponse
            {
                Datas = dtos,
                TotalCount = dtos.Count(),
            };
        }

    }
}
