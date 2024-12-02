using KovserHediyyeler.Application.DTOs.Tokens;

namespace KovserHediyyeler.Application.Features.Commands.WebUsers.Login
{
    public class UserLoginCommandResponse
    {
        public int StatusCode { get; set; }
    }
    public class UserLoginSuccessCommandResponse : UserLoginCommandResponse
    {
        public Token Token { get; set; }
    }

    public class UserLoginErrorCommandResponse : UserLoginCommandResponse
    {
        public string Message { get; set; }
    }
}
