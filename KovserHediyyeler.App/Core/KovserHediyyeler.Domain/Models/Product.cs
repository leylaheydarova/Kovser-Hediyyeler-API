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
        public double DiscountedPrice { get; set; }

    //Relationships
        public Guid PromotionID { get; set; }
        public Promotion Promotion { get; set; }
        public Guid DepartmentID { get; set; }
        public Department Department { get; set; }
        public Guid CategoryID { get; set; }
        public Category Category { get; set; }
        public Guid? BrandID { get; set; }
        public Brand? Brand { get; set; }
        public ICollection<OrderDetail> Orders { get; set; } = new List<OrderDetail>();
        public ICollection<ProductProperty> Properties { get; set; } = new List<ProductProperty>();
        public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
        public ICollection<ProductComment> Comments { get; set; } = new List<ProductComment>();
        public ICollection<Shop> Shops { get; set; } = new List<Shop>();
        public ICollection<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
        public ICollection<WishListItem> WishListItems { get; set; } = new List<WishListItem>();        
        
    }
}
