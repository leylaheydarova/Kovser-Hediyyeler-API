namespace KovserHedieyyeler.Application.DTOs.Baskets
{
    public class BasketGetDto
    {
        public string Id { get; set; }
        public int Count { get; set; }
        public double TotalPrice { get; set; }
        public string CustomerName { get; set; }
        public ICollection<BasketItemGetDto> Items { get; set; }
    }
}
