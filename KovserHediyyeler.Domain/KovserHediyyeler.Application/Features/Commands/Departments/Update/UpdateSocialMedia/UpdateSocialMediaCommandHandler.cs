using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Departments.Update.UpdateSocialMedia
{
    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommandRequest, UpdateSocialMediaCommandResponse>
    {
        readonly IDepartmentService _service;

        public UpdateSocialMediaCommandHandler(IDepartmentService service)
        {
            _service = service;
        }

        public async Task<UpdateSocialMediaCommandResponse> Handle(UpdateSocialMediaCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.UpdateDepartmentSocialMediaAsync(request.Dto, request.Id);

            return new UpdateSocialMediaCommandResponse()
            {
                Message = "Məlumat uğurla yeniləndi!"
            };
        }
    }
}
