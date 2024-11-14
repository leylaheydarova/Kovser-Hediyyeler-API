using KovserHediyyeler.Domain.Models.BaseModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace KovserHediyyeler.Domain.Models
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string LogoImage { get; set; }
        public string LogoImageURL { get; set; }
        //Relationships
        public ICollection<SocialMedia> SocialMedias { get; set; } = new List<SocialMedia>();
        //public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        //public ICollection<Product> Products { get; set; } = new List<Product>();

        ////Cross-tables
        //public ICollection<DepartmentPosition> DepartmentPositions { get; set; } = new List<DepartmentPosition>();
        //public ICollection<DepartmentPromotion> DepartmentPromotions { get; set; } = new List<DepartmentPromotion>();

        [NotMapped]
        public string DepartmentImagePath = "~/Assets/Images/Departments";
    }
}
