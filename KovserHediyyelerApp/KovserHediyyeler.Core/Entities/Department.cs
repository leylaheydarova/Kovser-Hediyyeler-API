using KovserHediyyeler.Core.Entities.BaseModel;
using KovserHediyyeler.Core.Entities.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Core.Entities
{
    public class Department:SocialMedias
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
    }
}
