using KovserHediyyeler.Domain.Models.BaseModels;

namespace KovserHediyyeler.Domain.Models
{
    public class Position:BaseEntity
    {
        public string Status { get; set; }

        //Relationships
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();

        //Cross-tables
        public ICollection<DepartmentPosition> DepartmentPositions { get; set; } = new List<DepartmentPosition>();
    }
}
