using KovserHediyyeler.Application.DTOs.WishLists;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.WishLists.Remove
{
    public class RemoveItemCommandRequest : IRequest<RemoveItemCommandResponse>
    {
        public WishListCommandDto Dto { get; set; }
    }
}
