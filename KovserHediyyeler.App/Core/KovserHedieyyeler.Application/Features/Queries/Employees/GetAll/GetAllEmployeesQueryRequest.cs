using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Employees.GetAll
{
    public class GetAllEmployeesQueryRequest:GetAllQueryRequest, IRequest<GetAllEmployeesQueryResponse>
    {
    }
}
