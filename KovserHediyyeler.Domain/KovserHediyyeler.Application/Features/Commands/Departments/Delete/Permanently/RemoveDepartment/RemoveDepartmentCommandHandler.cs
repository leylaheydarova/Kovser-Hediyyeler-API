using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Departments.Delete.Permanently.RemoveDepartment
{
    public class RemoveDepartmentCommandHandler : IRequestHandler<RemoveDepartmentCommandRequest, RemoveDepartmentCommandResponse>
    {
        readonly IDepartmentService _service;

        public RemoveDepartmentCommandHandler(IDepartmentService service)
        {
            _service = service;
        }

        public async Task<RemoveDepartmentCommandResponse> Handle(RemoveDepartmentCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.RemovePermanentlyDepartmentAsync(request.Id);

            return new RemoveDepartmentCommandResponse
            {
                Message = "Şöbə uğurla silindi!"
            };
        }
    }
}
