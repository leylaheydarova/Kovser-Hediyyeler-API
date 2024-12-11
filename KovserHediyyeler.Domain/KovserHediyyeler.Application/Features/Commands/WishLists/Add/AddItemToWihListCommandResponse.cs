using KovserHediyyeler.Application.DTOs.WishLists;

namespace KovserHediyyeler.Application.Features.Commands.WishLists.Add
{
    public class AddItemToWihListCommandResponse
    {
        public int StatusCode { get; set; } = 200;
        public WishListPostResultDto Dto { get; set; }
    }
}
