using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Domain.Models
{
    public class WebUser:IdentityUser
    {
        //Relationships
        public string BasketID { get; set; }
        public Basket Basket { get; set; }
        public string WishListID { get; set; }
        public WishList WishList { get; set; }
        public ICollection<Address> Address { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<CustomerBankCard> BankCards { get; set; } = new List<CustomerBankCard>();
        public ICollection<ProductComment> ProductComments { get; set; } = new List<ProductComment>();
       
    }
}
