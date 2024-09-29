using KovserHediyyeler.Domain.Models.BaseModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Domain.Models
{
    public class WebUser:IdentityUser<Guid>
    {
        //Relationships
        public Guid BasketID { get; set; }
        public Basket Basket { get; set; }
        public Guid WishListID { get; set; }
        public WishList WishList { get; set; }
        public ICollection<Address> Address { get; set; } = new List<Address>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<CustomerBankCard> BankCards { get; set; } = new List<CustomerBankCard>();
        public ICollection<ProductComment> ProductComments { get; set; } = new List<ProductComment>();
      
    }
}
