using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Exceptions.FailExceptions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.WebUsers.ForgotPassword
{
    public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommandRequest, ForgotPasswordCommandResponse>
    {
        readonly IUserService _service;

        public ForgotPasswordCommandHandler(IUserService service)
        {
            _service = service;
        }

        public async Task<ForgotPasswordCommandResponse> Handle(ForgotPasswordCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _service.ForgetPasswordAsync(request.Email, request.WebUserUri);
            if (result is null) throw new FailException();
            return new ForgotPasswordCommandResponse
            {
                Message = "",
                Token = result
            };
        }
    }
}
