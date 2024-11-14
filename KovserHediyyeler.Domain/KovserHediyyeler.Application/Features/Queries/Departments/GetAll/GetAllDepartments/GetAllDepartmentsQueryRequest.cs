using MediatR;


namespace KovserHedieyyeler.Application.Features.Queries.Departments.GetAll.GetAllDepartments
{
    public class GetAllDepartmentsQueryRequest : GetAllQueryRequest, IRequest<GetAllDepartmentsQueryResponse>
    {
    }
}
