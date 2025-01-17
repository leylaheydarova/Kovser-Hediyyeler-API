using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Employees;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Employees.Update.UpdateEmployees.UpdateTotalEmployee
{
    public class UpdateTEmployeeCommandHandler : IRequestHandler<UpdateTEmployeeCommandRequest, UpdateTEmployeeCommandResponse>
    {
        readonly IEmployeeService _service;

        public UpdateTEmployeeCommandHandler(IEmployeeService service)
        {
            _service = service;
        }

        public async Task<UpdateTEmployeeCommandResponse> Handle(UpdateTEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.UpdateTotalEmployeeAsync(request.Id, request.Dto);

            return new UpdateTEmployeeCommandResponse
            {
                Message = "İşçi məlumatları uğurla yeniləndi"
            };
        }
    }
}
