using KovserHediyyeler.Domain.Models.BaseModel;

namespace KovserHediyyeler.Domain.Models
{
    public class Shop : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }

        //Relationships
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<Product> Products { get; set; } = new List<Product>();
        //public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
