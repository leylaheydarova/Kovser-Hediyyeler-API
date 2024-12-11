namespace KovserHediyyeler.Application.DTOs.WishLists
{
    public class WishListItemGetDto
    {
        public string Id { get; set; }
        public string ImageName { get; set; }
        public string ImageURL { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public double DiscountedPrice { get; set; }
    }
}
