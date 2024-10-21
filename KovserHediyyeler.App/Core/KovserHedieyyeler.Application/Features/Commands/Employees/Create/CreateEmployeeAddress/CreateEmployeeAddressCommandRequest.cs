
using KovserHedieyyeler.Application.DTOs.Addresses;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Employees.Create.CreateEmployeeAddress
{
    public class CreateEmployeeAddressCommandRequest:CreateCommandRequest<AddressCommandDto>, IRequest<CreateEmployeeAddressCommandResponse>
    {
        public string EmployeeId { get; set; }
    }
}
