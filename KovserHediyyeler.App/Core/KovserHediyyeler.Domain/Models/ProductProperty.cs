using KovserHediyyeler.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Domain.Models
{
    public class ProductProperty:BaseEntity
    {
        public string Name { get; set; }
        public string Value { get; set; }
        
        //Relationships
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<Color>? Colors { get; set; } = new List<Color>();
    }
}
