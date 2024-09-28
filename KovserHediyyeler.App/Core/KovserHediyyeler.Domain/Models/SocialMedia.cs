using KovserHediyyeler.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Domain.Models
{
    public class SocialMedia:BaseEntity
    {
        public string NickName { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        

        //Relationships
        public Guid DepartmentID { get; set; }
        public Department Department { get; set; }
    }
}
