using KovserHediyyeler.Core.Entities.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Core.Entities.BaseModels
{
    public class Contact:BaseEntity
    {
        public string Phone {  get; set; }
        public string Email { get; set; }
    }
}
