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
        public ICollection<Order> Orders { get; set; } = new List<Order>();

        public string FullName
        {
            get
            {
                return MiddleName == null ? $"{FirstName} {LastName}" : $"{FirstName} {MiddleName} {LastName}";
            }
        }
    }
}
//todo: "Bank ilə ödəniş sistemini daha sonra artıracağam. Bu səbəblə, müvəqqəti olaraq ödəniş button üzərinə "Tezliklə ödəniş funksiyası gələcək" deyə yazılmalıdır."
//todo: "Zaman qalarsa, qəbz sistemini artırmaq və file olaraq müştərinin əldə etməsini təmin etmək"
//todo: Profile Photo
//todo: comment zamani adlarin gizledilmesi ve sekilli deyerlendirme