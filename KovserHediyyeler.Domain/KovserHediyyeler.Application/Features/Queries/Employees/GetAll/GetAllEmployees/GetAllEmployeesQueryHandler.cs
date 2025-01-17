using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.DTOs.Employees;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KovserHedieyyeler.Application.Features.Queries.Employees.GetAll.GetAllEmployees
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQueryRequest, GetAllEmployeesQueryResponse>
    {
        readonly IEmployeeService _service;

        public GetAllEmployeesQueryHandler(IEmployeeService service)
        {
            _service = service;
        }

        public async Task<GetAllEmployeesQueryResponse> Handle(GetAllEmployeesQueryRequest request, CancellationToken cancellationToken)
        {
            var dtos = await _service.GetAllEmployeesAsync(request.Page, request.Size);
            return new GetAllEmployeesQueryResponse
            {
                Datas = dtos,
                TotalCount = dtos.Count()
            };
        }
    }
}
