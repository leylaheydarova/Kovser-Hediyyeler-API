using KovserHediyyeler.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Domain.Models
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool isSingleColour { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }

        //Relationships
        public string DepartmentID { get; set; }
        public Department Department { get; set; }
        public string CategoryID { get; set; }
        public Category Category { get; set; }
        public string? BrandID { get; set; }
        public Brand? Brand { get; set; }
        public string? DiscountID { get; set; }
        public Discount? Discount { get; set; }
        public ICollection<OrderDetail> Orders { get; set; } = new List<OrderDetail>();
        public ICollection<ProductProperty> Properties { get; set; }
        public ICollection<ProductImage> Images { get; set; }
        public ICollection<ProductComment> Comments { get; set; }
        public ICollection<Shop> Shops { get; set; } = new List<Shop>();
        //public ICollection<NewOrder> NewOrders { get; set; } = new List<NewOrder>();
        
        
    }
}
