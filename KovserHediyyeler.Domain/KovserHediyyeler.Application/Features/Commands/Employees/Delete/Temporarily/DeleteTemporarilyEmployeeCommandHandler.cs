using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Addresses;
using KovserHediyyeler.Application.Repositories.Employees;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Employees.Delete.Temporarily
{
    public class DeleteTemporarilyEmployeeCommandHandler : IRequestHandler<DeleteTemporarilyEmployeeCommandRequest, DeleteTemporarilyEmployeeCommandResponse>
    {
        readonly IEmployeeService _service;

        public DeleteTemporarilyEmployeeCommandHandler(IEmployeeService service)
        {
            _service = service;
        }

        public async Task<DeleteTemporarilyEmployeeCommandResponse> Handle(DeleteTemporarilyEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.DeleteTemporarilyEmployeeAsync(request.Id);

            return new DeleteTemporarilyEmployeeCommandResponse
            {
                Message = "İşçi müvəqqəti silinmişdir!"
            };
        }

    }
}
