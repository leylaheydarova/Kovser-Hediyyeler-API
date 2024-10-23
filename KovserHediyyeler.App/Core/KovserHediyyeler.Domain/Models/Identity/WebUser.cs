using Microsoft.AspNetCore.Identity;

namespace KovserHediyyeler.Domain.Models.Identity
{
    public class WebUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public bool isDeleted { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
        //Relationships
        public Guid BasketID { get; set; }
        public Basket Basket { get; set; }
        public Guid WishListID { get; set; }
        public WishList WishList { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<CustomerBankCard> BankCards { get; set; } = new List<CustomerBankCard>();
        public ICollection<ProductComment> ProductComments { get; set; } = new List<ProductComment>();

        //Cross-tables
        public ICollection<AddressWebUser> AddressWebUsers { get; set; } = new List<AddressWebUser>();
        //todo: Profile Photo

    }
}
