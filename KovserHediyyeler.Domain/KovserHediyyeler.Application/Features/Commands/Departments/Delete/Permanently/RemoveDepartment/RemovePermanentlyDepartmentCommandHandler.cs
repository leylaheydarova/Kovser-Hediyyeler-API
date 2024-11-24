using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Departments.Delete.Permanently.RemoveDepartment
{
    public class RemovePermanentlyDepartmentCommandHandler : IRequestHandler<RemovePermanentlyDepartmentCommandRequest, RemovePermanentlyDepartmentCommandResponse>
    {
        readonly IDepartmentService _service;

        public RemovePermanentlyDepartmentCommandHandler(IDepartmentService service)
        {
            _service = service;
        }

        public async Task<RemovePermanentlyDepartmentCommandResponse> Handle(RemovePermanentlyDepartmentCommandRequest request, CancellationToken cancellationToken)
        {

            await _service.RemovePermanentlyDepartmentAsync(request.Id);

            return new RemovePermanentlyDepartmentCommandResponse
            {
                Message = "Şöbə uğurla silindi!"
            };
        }
    }
}
