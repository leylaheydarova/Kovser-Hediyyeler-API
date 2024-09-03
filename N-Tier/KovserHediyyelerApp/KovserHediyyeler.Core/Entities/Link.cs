using KovserHediyyeler.Core.Entities.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Core.Entities
{
    public class Link:BaseEntity
    {
        public string? username { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Department_ID { get; set; }
        public Department department { get; set; }
    }
}
