using KovserHediyyeler.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Domain.Models
{
    public class Department:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string LogoImage { get; set; }
        public string LogoImageURL { get; set; }
        //Relationships
        public ICollection<Category>Categories { get; set; }
        public ICollection<SocialMedia> SocialMedias { get; set; }  
        public ICollection<Employee> Employees { get; set; }    
        public ICollection<Product> Products { get; set; }
        public ICollection<Position> Positions { get; set; }
        public ICollection<NewOrder> NewOrders { get; set; } = new List<NewOrder>();
        public ICollection<Discount> Discounts { get; set; } = new List<Discount>();
    }
}
