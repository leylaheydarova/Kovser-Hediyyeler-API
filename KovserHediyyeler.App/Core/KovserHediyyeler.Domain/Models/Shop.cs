using KovserHediyyeler.Domain.Models.BaseModels;

namespace KovserHediyyeler.Domain.Models
{
    public class Shop:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone {  get; set; }

        //Relationships
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();

        //Cross-tables
        public ICollection<ProductShop> ProductShops { get; set; } = new List<ProductShop>();

    }
}
