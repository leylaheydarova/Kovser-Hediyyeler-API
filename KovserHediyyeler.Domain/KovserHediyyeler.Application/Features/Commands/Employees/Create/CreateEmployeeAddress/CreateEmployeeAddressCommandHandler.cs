using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Employees.Create.CreateEmployeeAddress
{
    public class CreateEmployeeAddressCommandHandler : IRequestHandler<CreateEmployeeAddressCommandRequest, CreateEmployeeAddressCommandResponse>
    {
        readonly IEmployeeService _service;

        public CreateEmployeeAddressCommandHandler(IEmployeeService service)
        {
            _service = service;
        }

        public async Task<CreateEmployeeAddressCommandResponse> Handle(CreateEmployeeAddressCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.CreateEmployeeAddressAsync(request.Dto, request.EmployeeId);

            return new CreateEmployeeAddressCommandResponse
            {
                StatusCode = 201,
                Message = "İşçi ünvanı uğurla əlavə edilmişdir!"
            };
        }

    }
}
