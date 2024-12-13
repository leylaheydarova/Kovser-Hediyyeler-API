using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Baskets.Update.UpdateIsSelected
{
    public class SetIsSelectedTrueCommandRequest : IRequest<SetIsSelectedTrueCommandResponse>
    {
        public required List<Guid> ProductIDs { get; set; }
        public string CustomerId { get; set; }
    }
}
