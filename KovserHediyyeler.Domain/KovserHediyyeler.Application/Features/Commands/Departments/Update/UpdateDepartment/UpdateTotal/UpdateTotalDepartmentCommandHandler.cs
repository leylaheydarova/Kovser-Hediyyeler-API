using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Departments.Update.UpdateDepartment.UpdateTotal
{
    public class UpdateTotalDepartmentCommandHandler : IRequestHandler<UpdateTotalDepartmentCommandRequest, UpdateTotalDepartmentCommandResponse>
    {
        readonly IDepartmentService _service;

        public UpdateTotalDepartmentCommandHandler(IDepartmentService service)
        {
            _service = service;
        }

        public async Task<UpdateTotalDepartmentCommandResponse> Handle(UpdateTotalDepartmentCommandRequest request, CancellationToken cancellationToken)
        {
            _service.UpdateTotalDepartmentAsync(request.Dto, request.Id);

            return new UpdateTotalDepartmentCommandResponse
            {
                Message = "Şöbə məlumatları uğurla yeniləndi!"
            };
        }
    }
}
