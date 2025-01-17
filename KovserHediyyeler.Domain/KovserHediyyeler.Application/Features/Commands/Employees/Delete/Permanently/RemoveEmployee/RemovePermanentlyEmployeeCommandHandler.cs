using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Repositories.Addresses;
using KovserHediyyeler.Application.Repositories.Employees;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Employees.Delete.Permanently.RemoveEmployee
{
    public class RemovePermanentlyEmployeeCommandHandler : IRequestHandler<RemovePermanentlyEmployeeCommandRequest, RemovePermanentlyEmployeeCommandResponse>
    {
        readonly IEmployeeService _service;

        public RemovePermanentlyEmployeeCommandHandler(IEmployeeService service)
        {
            _service = service;
        }

        public async Task<RemovePermanentlyEmployeeCommandResponse> Handle(RemovePermanentlyEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.RemovePermanentlyEmployeeAsync(request.Id);
            
            return new RemovePermanentlyEmployeeCommandResponse
            {
                Message = "İşçi uğurla silinmişdir"
            };
        }
    }
}
