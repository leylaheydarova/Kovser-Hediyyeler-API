//using KovserHedieyyeler.Application.Abstractions.Services;
//using MediatR;

//namespace KovserHedieyyeler.Application.Features.Commands.WebUsers.Register
//{
//    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest, RegisterUserCommandResponse>
//    {
//        readonly IUserService _userService;

//        public RegisterUserCommandHandler(IUserService userService)
//        {
//            _userService = userService;
//        }

//        public async Task<RegisterUserCommandResponse> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
//        {
//            RegisterUserCommandResponse response = await _userService.CreateAsync(new()
//            {
//                Dto = request.Dto
//            });

//            return new()
//            {
//                Message = response.Message,
//                isSucceeded = response.isSucceeded
//            };
//        }
//    }
//}
