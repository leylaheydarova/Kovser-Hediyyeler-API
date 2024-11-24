using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Departments.Delete.Temporarily
{
    public class DeleteTemporarilyDepartmentCommandHandler : IRequestHandler<DeleteTemporarilyDepartmentCommandRequest, DeleteTemporarilyDepartmentCommandResponse>
    {
        readonly IDepartmentService _service;

        public DeleteTemporarilyDepartmentCommandHandler(IDepartmentService service)
        {
            _service = service;
        }

        public async Task<DeleteTemporarilyDepartmentCommandResponse> Handle(DeleteTemporarilyDepartmentCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.DeleteTemporarilyDepartment(request.Id);

            return new DeleteTemporarilyDepartmentCommandResponse
            {
                Message = "Şöbə müvəqqəti silindi!"
            };
        }
    }
}
