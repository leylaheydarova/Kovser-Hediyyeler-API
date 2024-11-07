using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace KovserHediyyeler.Domain.Models.Identity
{
    public class WebUser : IdentityUser<string>
    {
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public bool isDeleted { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
        //Relationships
        public Basket Basket { get; set; }
        public WishList WishList { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<CustomerBankCard> BankCards { get; set; } = new List<CustomerBankCard>();
        public ICollection<ProductComment> ProductComments { get; set; } = new List<ProductComment>();
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        
        //todo: Profile Photo
        public string FullName
        {
            get
            {
                return MiddleName == null ? $"{FirstName} {LastName}" : $"{FirstName} {MiddleName} {LastName}";
            }
        }
    }
}
