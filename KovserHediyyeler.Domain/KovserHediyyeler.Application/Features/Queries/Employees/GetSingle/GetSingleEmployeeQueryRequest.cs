using MediatR;


namespace KovserHedieyyeler.Application.Features.Queries.Employees.GetSingle
{
    public class GetSingleEmployeeQueryRequest:GetSingleQueryRequest, IRequest<GetSingleEmployeeQueryResponse>
    {
    }
}
