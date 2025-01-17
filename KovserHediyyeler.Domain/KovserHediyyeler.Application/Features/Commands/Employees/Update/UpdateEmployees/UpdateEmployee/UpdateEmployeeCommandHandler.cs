using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Employees.Update.UpdateEmployees.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommandRequest, UpdateEmployeeCommandResponse>
    {
        readonly IEmployeeService _service;

        public UpdateEmployeeCommandHandler(IEmployeeService service)
        {
            _service = service;
        }

        public async Task<UpdateEmployeeCommandResponse> Handle(UpdateEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.UpdateEmployeeAsync(request.Id, request.Dto);

            return new UpdateEmployeeCommandResponse
            {
                Message = "Məlumat uğurla yeniləndi!"
            };
        }
    }
}
