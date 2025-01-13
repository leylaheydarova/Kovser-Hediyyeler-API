namespace KovserHediyyeler.Application.DTOs.Baskets
{
    public class BasketCommandDto
    {
        public Guid ProductId { get; set; }
        public int Count { get; set; }
        public string UserId { get; set; }
        public Guid ColorId { get; set; }
        public Guid SizeId { get; set; }
    }
}
