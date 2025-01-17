using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Employees.Create.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommandRequest, CreateEmployeeCommandResponse>
    {
        readonly IEmployeeService _service;

        public CreateEmployeeCommandHandler(IEmployeeService service)
        {
            _service = service;
        }

        public async Task<CreateEmployeeCommandResponse> Handle(CreateEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.CreateEmployeeAsync(request.Dto);

            return new CreateEmployeeCommandResponse
            {
                StatusCode = 201,
                Message = "İşçi uğurla əlavə edildi!"
            };
        }
    }
}
