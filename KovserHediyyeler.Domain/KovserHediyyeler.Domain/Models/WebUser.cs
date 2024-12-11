using Microsoft.AspNetCore.Identity;

namespace KovserHediyyeler.Domain.Models
{
    public class WebUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public bool isDeleted { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }

        //Relations
        public Basket Basket { get; set; }
        public WishList WishList { get; set; }
        public ICollection<Address> Addresses { get; set; } = new List<Address>();

        public string FullName
        {
            get
            {
                return MiddleName == null ? $"{FirstName} {LastName}" : $"{FirstName} {MiddleName} {LastName}";
            }
        }
    }
}
