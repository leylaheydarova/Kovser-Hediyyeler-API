using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.WishLists.Add
{
    public class AddItemToWihListCommandRequest : IRequest<AddItemToWihListCommandResponse>
    {
        public string CustomerId { get; set; }
        public Guid ProductId { get; set; }
    }
}
