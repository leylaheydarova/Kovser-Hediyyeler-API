using KovserHedieyyeler.Application.DTOs.Products.Products;
using KovserHediyyeler.Domain.Enums;

namespace KovserHedieyyeler.Application.DTOs.Promotion
{
    public class PromotionCommandDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public DiscountPersentage? DiscountPersentage { get; set; }
        public double? DiscountedPrice { get; set; }
        public ICollection<ProductGetAllDto> Products { get; set; } = new List<ProductGetAllDto>();
        public DateTime? StartDate { get; set; }
        public DateTime ExpireDate { get; set; }


    }
}
