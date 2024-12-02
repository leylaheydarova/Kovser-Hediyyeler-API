using KovserHedieyyeler.Application.Features.Commands;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.WebUsers.Remove.RemoveAddress
{
    public class RemoveUserAddressCommandRequest : DeleteCommandRequest, IRequest<RemoveUserAddressCommandResponse>
    {
        public string UserIdOrEmail { get; set; }
    }
}
