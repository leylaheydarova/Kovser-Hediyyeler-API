using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Departments.Recover
{
    public class RecoverDepartmentCommandHandler : IRequestHandler<RecoverDepartmentCommandRequest, RecoverDepartmentCommandResponse>
    {
        readonly IDepartmentService _service;

        public RecoverDepartmentCommandHandler(IDepartmentService service)
        {
            _service = service;
        }

        public async Task<RecoverDepartmentCommandResponse> Handle(RecoverDepartmentCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.RecoverDepartmentAsync(request.Id);

            return new RecoverDepartmentCommandResponse
            {
                Message = "Şöbə məlumatları uğurla bərpa edilmişdir!"
            };
        }
    }
}
