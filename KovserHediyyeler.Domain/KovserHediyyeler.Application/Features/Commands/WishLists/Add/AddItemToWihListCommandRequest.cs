using KovserHediyyeler.Application.DTOs.WishLists;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.WishLists.Add
{
    public class AddItemToWihListCommandRequest : IRequest<AddItemToWihListCommandResponse>
    {
        public WishListCommandDto Dto { get; set; }
    }
}
