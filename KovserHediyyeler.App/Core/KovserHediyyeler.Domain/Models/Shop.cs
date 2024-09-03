using KovserHediyyeler.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Domain.Models
{
    public class Shop:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone {  get; set; }

        //Relationships
        public ICollection<Product> Products { get; set;} = new List<Product>();
    }
}
