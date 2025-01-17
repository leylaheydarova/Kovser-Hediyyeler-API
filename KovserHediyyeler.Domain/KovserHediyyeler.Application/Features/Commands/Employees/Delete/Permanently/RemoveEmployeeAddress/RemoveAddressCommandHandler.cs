using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Addresses;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Employees.Delete.Permanently.RemoveEmployeeAddress
{
    public class RemoveAddressCommandHandler : IRequestHandler<RemoveAddressCommandRequest, RemoveAddressCommandResponse>
    {
        readonly IEmployeeService _service;

        public RemoveAddressCommandHandler(IEmployeeService service)
        {
            _service = service;
        }

        public async Task<RemoveAddressCommandResponse> Handle(RemoveAddressCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.RemovePermanentlyEmployeeAddressAsync(request.Id);

            return new RemoveAddressCommandResponse
            {
                Message = "İşçi ünvanı uğurla silinmişdir"
            };
        }
    }
}
