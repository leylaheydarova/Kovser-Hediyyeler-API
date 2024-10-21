using KovserHediyyeler.Domain.Models.BaseModels;
namespace KovserHediyyeler.Domain.Models
{
    public class Employee:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public bool isRemote { get; set; }

        //Relationships
        public Guid DepartmentID { get; set; }
        public Department Department { get; set; }
        public Guid PositionID { get; set; }
        public Position Position { get; set; }
        public Guid? ShopID { get; set; }
        public Shop? Shop { get; set; }
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}
