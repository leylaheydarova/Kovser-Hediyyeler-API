using KovserHediyyeler.Domain.Models.BaseModels;

namespace KovserHediyyeler.Domain.Models
{
    public class CategoryDepartment:BaseEntity
    {
        public Guid CategoryID { get; set; }
        public Category Category { get; set; }
        public Guid DepartmentID { get; set; }
        public Department Department { get; set; }
    }
}
