using KovserHediyyeler.Domain.Models.BaseModel;

namespace KovserHediyyeler.Domain.Models
{
    public class Position : BaseEntity
    {
        public string Status { get; set; }

        //Relationships
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();



    }
}
