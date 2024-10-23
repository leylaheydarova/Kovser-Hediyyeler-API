using KovserHedieyyeler.Application.DTOs.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Features.Commands.WebUsers.Login
{
    public class UserLoginCommandResponse
    {
        
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
