namespace KovserHediyyeler.Application.DTOs.WishLists
{
    public class WishListGetDto
    {
        public string Id { get; set; }
        public string CustomerName { get; set; }
        public ICollection<WishListItemGetDto> ListItems { get; set; } = new List<WishListItemGetDto>();
    }
}
