using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.WebUsers.Remove.RemoveAccount
{
    public class RemoveAccountCommandRequest : IRequest<RemoveAccountCommandResponse>
    {
        public string UserIdOrName { get; set; }
    }
}
