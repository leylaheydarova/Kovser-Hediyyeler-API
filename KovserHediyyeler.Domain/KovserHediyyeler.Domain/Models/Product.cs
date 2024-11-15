using KovserHediyyeler.Domain.Models.BaseModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace KovserHediyyeler.Domain.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool isSingleColour { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public double DiscountedPrice { get; set; }
        public double ProductAverageRating { get; set; } = 5;

        //Relationships
        [ForeignKey(nameof(Promotion))]
        public Guid? PromotionID { get; set; }
        public Promotion? Promotion { get; set; }
        [ForeignKey(nameof(Department))]
        public Guid DepartmentID { get; set; }
        public Department Department { get; set; }

        [ForeignKey(nameof(Category))]
        public Guid CategoryID { get; set; }
        public Category Category { get; set; }

        [ForeignKey(nameof(Brand))]
        public Guid? BrandID { get; set; }
        public Brand? Brand { get; set; }
        //public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public ICollection<ProductProperty> Properties { get; set; } = new List<ProductProperty>();
        public ICollection<ProductImageFile> Images { get; set; } = new List<ProductImageFile>();
        //public ICollection<ProductComment> Comments { get; set; } = new List<ProductComment>();
        //public ICollection<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
        //public ICollection<WishListItem> WishListItems { get; set; } = new List<WishListItem>();

        public ICollection<Shop> Shops { get; set; } = new List<Shop>();

        [NotMapped]
        public string ProductImagePath = "~/Assets/Images/Products";
    }
}
