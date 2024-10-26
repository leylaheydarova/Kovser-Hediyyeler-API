//using KovserHedieyyeler.Application.Abstractions.Services;
//using MediatR;

//namespace KovserHedieyyeler.Application.Features.Commands.WebUsers.PasswordReset
//{
//    public class PasswordResetCommandHandler:IRequestHandler<PasswordResetCommandRequest, PasswordResetCommandResponse>
//    {
//        readonly IAuthService _authService;

//        public PasswordResetCommandHandler(IAuthService authService)
//        {
//            _authService = authService;
//        }
//        public async Task<PasswordResetCommandResponse> Handle(PasswordResetCommandRequest request, CancellationToken cancellationToken)
//        {
//            await _authService.PasswordResetAsnyc(request.Email);
//            return new();
//        }
//    }
//}
