using KovserHediyyeler.Application.DTOs.Employees;
using KovserHediyyeler.Application.Repositories.Employees;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KovserHedieyyeler.Application.Features.Queries.Employees.GetAll.GetAllEmployees
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQueryRequest, GetAllEmployeesQueryResponse>
    {
        readonly IEmployeeReadRepository _repository;

        public GetAllEmployeesQueryHandler(IEmployeeReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAllEmployeesQueryResponse> Handle(GetAllEmployeesQueryRequest request, CancellationToken cancellationToken)
        {
            var query = _repository.GetAllWhere(x => !x.isDeleted, false, "Position");
            int totalCount = query.Count();

            List<EmployeeGetAllDto> dtos = new List<EmployeeGetAllDto>();
            dtos = await query.Skip(request.Page * request.Size)
                .Take(request.Size)
                .Select(e => new EmployeeGetAllDto
                {
                    Id = e.ID.ToString(),
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    PositionName = e.Position.Status
                }).ToListAsync();
            return new GetAllEmployeesQueryResponse
            {
                Datas = dtos,
                TotalCount = totalCount
            };
        }
    }
}
