using KovserHediyyeler.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Domain.Models
{
    public class Brand:BaseEntity
    {
        public string Name { get; set; }
        public string? Image { get; set; }
    }
}
