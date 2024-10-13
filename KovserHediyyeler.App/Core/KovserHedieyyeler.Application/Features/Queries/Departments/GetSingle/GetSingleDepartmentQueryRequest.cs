using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Departments.GetSingle
{
    public class GetSingleDepartmentQueryRequest:GetSingleQueryRequest, IRequest<GetSingleDepartmentQueryResponse>
    {
    }
}
