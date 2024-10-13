using MediatR;


namespace KovserHedieyyeler.Application.Features.Queries.Departments.GetAll
{
    public class GetAllDepartmentsQueryRequest:GetAllQueryRequest, IRequest<GetAllDepartmentsQueryResponse>
    {
    }
}
