using KovserHediyyeler.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Domain.Models
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }

        //Relationships
        public ICollection<Department> Departments { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<NewOrder > NewOrders { get; set; }
        public ICollection<Discount> Discounts { get; set; } = new List<Discount>();
    }
}
