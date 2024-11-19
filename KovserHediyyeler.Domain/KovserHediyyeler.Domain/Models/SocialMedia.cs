using KovserHediyyeler.Domain.Models.BaseModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace KovserHediyyeler.Domain.Models
{
    public class SocialMedia : BaseEntity
    {
        public string NickName { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }


        //Relationships
        [ForeignKey(nameof(Department))]
        public Guid DepartmentID { get; set; }
        public Department Department { get; set; }
    }
}
