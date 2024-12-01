using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Roles.Update
{
    public class UpdateRolCommandRequest : IRequest<UpdateRolCommandResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }

    }
}
