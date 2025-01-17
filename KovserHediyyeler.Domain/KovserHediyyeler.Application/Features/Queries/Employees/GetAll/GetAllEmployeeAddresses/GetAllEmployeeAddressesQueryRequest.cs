using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Employees.GetAll.GetAllEmployeeAddresses
{
    public class GetAllEmployeeAddressesQueryRequest : GetAllQueryRequest, IRequest<GetAllEmployeeAddressesQueryResponse>
    {
        public Guid EmployeeId { get; set; }
    }
}
