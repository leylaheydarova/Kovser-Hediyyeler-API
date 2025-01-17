using KovserHedieyyeler.Application.DTOs.Addresses;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Employees.Update.UpdateEmployeeAddress
{
    public class UpdateEmployeeAddressCommandRequest:UpdateCommandRequest<AddressUpdateDto>, IRequest<UpdateEmployeeAddressCommandResponse>
    {
        public Guid EmployeeId {  get; set; }
    }
}
