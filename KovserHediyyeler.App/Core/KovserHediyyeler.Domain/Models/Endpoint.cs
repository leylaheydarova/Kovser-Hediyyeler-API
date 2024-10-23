using KovserHediyyeler.Domain.Models.BaseModels;
using KovserHediyyeler.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Domain.Models
{
    public class Endpoint:BaseEntity
    {
        public Endpoint()
        {
            Roles = new HashSet<UserRole>();
        }
        public string ActionType { get; set; }
        public string HttpType { get; set; }
        public string Definition { get; set; }
        public string Code { get; set; }

        public Menu Menu { get; set; }
        public ICollection<UserRole> Roles { get; set; }
    }
}
