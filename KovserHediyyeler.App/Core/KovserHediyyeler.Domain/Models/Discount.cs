using KovserHediyyeler.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Domain.Models
{
    public class Discount:BaseEntity
    {
        public double Persentage { get; set; }

        //Relationships
        public ICollection<OrderDetail> OrderDetails { get; set; }  = new List<OrderDetail>();
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<Category> Categories { get; set; } = new List<Category>();
        public ICollection<Department> Departments { get; set; } = new List<Department>();
        public ICollection<Basket> Baskets { get; set; } = new List<Basket>();
    }
}
