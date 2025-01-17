using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Addresses;
using KovserHediyyeler.Domain.Enums;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Employees.Update.UpdateEmployeeAddress
{
    public class UpdateEmployeeAddressCommandHandler : IRequestHandler<UpdateEmployeeAddressCommandRequest, UpdateEmployeeAddressCommandResponse>
    {
        readonly IEmployeeService _service;

        public UpdateEmployeeAddressCommandHandler(IEmployeeService service)
        {
            _service = service;
        }

        public async Task<UpdateEmployeeAddressCommandResponse> Handle(UpdateEmployeeAddressCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.UpdateEmployeeAddressAsync(request.Id, request.EmployeeId, request.Dto);

            return new UpdateEmployeeAddressCommandResponse
            {
                Message = "İşçi ünvanı uğurla dəyişdirildi!"
            };
        }

    }
}
