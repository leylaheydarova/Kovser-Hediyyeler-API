using KovserHediyyeler.Domain.Models.BaseModels;

namespace KovserHediyyeler.Domain.Models
{
    public class DepartmentPosition:BaseEntity
    {
        public Guid DepartmentID { get; set; }
        public Department Department { get; set; }
        public Guid PositionID { get; set; }
        public Position Position { get; set; }
    }
}
