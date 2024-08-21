using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Core.Entities.BaseModel
{
    public class BaseEntity
    {
        public Guid ID { get; set; }
        public DateTime Createdat { get; set; }
        public DateTime? Updatedat { get; set; }
        public DateTime? Deletedat { get; set; }
        public bool isDeleted { get; set; }
    }
}
