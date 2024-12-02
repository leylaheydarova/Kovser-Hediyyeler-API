using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.WebUsers.Update.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
    {
        readonly IUserService _service;

        public UpdateUserCommandHandler(IUserService service)
        {
            _service = service;
        }

        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.UpdateUserAsync(request.UserIdOrEmail, request.Dto);
            return new UpdateUserCommandResponse
            {
                Message = "İstifadəçi məlumatları uğurla yeniləndi!"
            };
        }
    }
}
