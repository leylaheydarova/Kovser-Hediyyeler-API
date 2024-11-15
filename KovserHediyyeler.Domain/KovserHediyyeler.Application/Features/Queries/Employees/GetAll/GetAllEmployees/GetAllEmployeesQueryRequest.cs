using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Employees.GetAll.GetAllEmployees
{
    public class GetAllEmployeesQueryRequest : GetAllQueryRequest, IRequest<GetAllEmployeesQueryResponse>
    {
    }
}
