using KovserHediyyeler.Domain.Models.BaseModels;

namespace KovserHediyyeler.Domain.Models
{
    public class DepartmentPromotion:BaseEntity
    {
        public Guid DepartmentID { get; set; }
        public Department Department { get; set; }
        public Guid PromotionID { get; set; }
        public Promotion Promotion { get; set; }
    }
}
