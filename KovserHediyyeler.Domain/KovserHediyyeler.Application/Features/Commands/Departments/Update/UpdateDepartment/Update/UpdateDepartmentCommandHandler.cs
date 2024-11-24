using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Departments.Update.UpdateDepartment.Update
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommandRequest, UpdateDepartmentCommandResponse>
    {
        readonly IDepartmentService _service;

        public UpdateDepartmentCommandHandler(IDepartmentService service)
        {
            _service = service;
        }

        public async Task<UpdateDepartmentCommandResponse> Handle(UpdateDepartmentCommandRequest request, CancellationToken cancellationToken)
        {

            await _service.UpdateDepartmentAsync(request.Dto, request.Id);

            return new UpdateDepartmentCommandResponse
            {
                Message = "Məlumat uğurla yeniləndi!"
            };
        }
    }
}
