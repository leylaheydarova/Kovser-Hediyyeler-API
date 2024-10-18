using KovserHediyyeler.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Domain.Models
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        [ForeignKey(nameof(Category))]
        public Guid? ParentId { get; set; }
        public Category? ParentCategory { get; set; }

        //Relationships
        public ICollection<Department> Departments { get; set; } = new List<Department>();
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<Promotion> Promotions { get; set; } = new List<Promotion>();

    }
}
