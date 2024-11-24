using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Departments.Delete.Permanently.RemoveSocialMedia
{
    public class RemoveSocialMediaCommandHandler : IRequestHandler<RemoveSocialMediaCommandRequest, RemoveSocialMediaCommandResponse>
    {
        readonly IDepartmentService _service;

        public RemoveSocialMediaCommandHandler(IDepartmentService service)
        {
            _service = service;
        }

        public async Task<RemoveSocialMediaCommandResponse> Handle(RemoveSocialMediaCommandRequest request, CancellationToken cancellationToken)
        {

            await _service.RemovePermanentlyDepartmentSocialMediaAsync(request.Id);

            return new RemoveSocialMediaCommandResponse
            {
                Message = "Sosyal Media məlumatları uğurla silinmişdir!"
            };
        }
    }
}
