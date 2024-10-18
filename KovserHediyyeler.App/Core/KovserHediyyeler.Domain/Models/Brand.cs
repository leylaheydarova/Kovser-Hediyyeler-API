using KovserHediyyeler.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Domain.Models
{
    public class Brand:BaseEntity
    {
        public string Name { get; set; }
        public string? Image { get; set; }
        public string? ImageURL { get; set; }

        //Relationships
        public ICollection<Product> Products { get; set; } = new List<Product>();
        [NotMapped]
        public string BrandImagePath = "~/Assets/Images/Brands";
    }
}
