using KovserHediyyeler.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Domain.Models
{
    public class Shipping : BaseEntity
    {
        public bool isShipping {get; set;}

        //Relationships
        public ICollection<Order> Orders { get; set;}
    }
}
