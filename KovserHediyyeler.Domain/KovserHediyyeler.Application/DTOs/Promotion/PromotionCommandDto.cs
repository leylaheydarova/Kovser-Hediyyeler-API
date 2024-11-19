using KovserHediyyeler.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace KovserHedieyyeler.Application.DTOs.Promotion
{
    public class PromotionCommandDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public DiscountPersentage? DiscountPersentage { get; set; }
        public IFormFile Image { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime ExpireDate { get; set; }

    }
}
