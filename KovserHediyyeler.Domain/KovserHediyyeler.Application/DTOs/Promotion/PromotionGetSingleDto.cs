namespace KovserHedieyyeler.Application.DTOs.Promotion
{
    public class PromotionGetSingleDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double DiscountPersentage { get; set; }
        public double DiscountedPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpireDate { get; set; }
        //public ICollection<ProductGetAllDto> Products { get; set; }
    }
}
