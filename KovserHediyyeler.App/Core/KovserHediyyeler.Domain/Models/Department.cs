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
        public ICollection<Category> Categories { get; set; } = new List<Category>();
        public ICollection<SocialMedia> SocialMedias { get; set; } = new List<SocialMedia>();
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<Position> Positions { get; set; } = new List<Position>();
        public ICollection<Discount> Discounts { get; set; } = new List<Discount>();
    }
}
