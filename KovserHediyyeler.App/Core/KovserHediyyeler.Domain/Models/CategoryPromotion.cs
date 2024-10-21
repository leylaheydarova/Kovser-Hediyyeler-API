using KovserHediyyeler.Domain.Models.BaseModels;

namespace KovserHediyyeler.Domain.Models
{
    public class CategoryPromotion:BaseEntity
    {
        public Guid CategoryID { get; set; }
        public Category Category { get; set; }
        public Guid PromotionID { get; set; }
        public Promotion Promotion { get; set; }    
    }
}
