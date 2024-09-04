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
        public Department Department { get; set; }
        public Category Category { get; set; }
        public Brand? Brand { get; set; }
        public Discount? Discount { get; set; }
        public ICollection<ProductProperty> Properties { get; set; }
        public ICollection<ProductImage> Images { get; set; }
        public ICollection<Shop> Shops { get; set; } = new List<Shop>();
        public ICollection<NewOrder> NewOrders { get; set; }
        
        
    }
}
