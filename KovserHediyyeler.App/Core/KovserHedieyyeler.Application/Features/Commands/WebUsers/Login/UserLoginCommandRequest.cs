using KovserHedieyyeler.Application.DTOs.Accounts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Features.Commands.WebUsers.Login
{
    public class UserLoginCommandRequest:IRequest<UserLoginCommandResponse>
    {
        public LoginDto Dto { get; set; }
    }
}
