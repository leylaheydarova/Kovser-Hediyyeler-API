using KovserHediyyeler.Domain.Enums;
using KovserHediyyeler.Domain.Models.BaseModels;

namespace KovserHediyyeler.Domain.Models
{
    public class Promotion:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public DiscountPersentage? DiscountPersentage { get; set; }
        public double? DiscountedPrice { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime ExpireDate {  get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();

        //Cross-tables
        public ICollection<DepartmentPromotion> DepartmentPromotions = new List<DepartmentPromotion>();
        public ICollection<CategoryPromotion> CategoryPromotions = new List<CategoryPromotion>();

    }
}
