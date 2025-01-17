using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Addresses;
using KovserHediyyeler.Application.Repositories.Employees;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Employees.Update.Recover
{
    public class RecoverEmployeeCommandHandler : IRequestHandler<RecoverEmployeeCommandRequest, RecoverEmployeeCommandResponse>
    {
        readonly IEmployeeService _service;

        public RecoverEmployeeCommandHandler(IEmployeeService service)
        {
            _service = service;
        }

        public async Task<RecoverEmployeeCommandResponse> Handle(RecoverEmployeeCommandRequest request, CancellationToken cancellationToken)
        {

            await _service.RecoverEmployeeDataAsync(request.Id);

            return new RecoverEmployeeCommandResponse()
            {
                Message = "İşçi məlumatları uğurla bərpa edilmişdir!"
            };
        }

    }
}
