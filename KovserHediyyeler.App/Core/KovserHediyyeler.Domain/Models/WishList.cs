using KovserHediyyeler.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Domain.Models
{
    public class WishList:BaseEntity
    {
       public ICollection<WebUser> WebUsers { get; set; }
        public ICollection<WishListItem> ListItems { get; set; }
    }
}
