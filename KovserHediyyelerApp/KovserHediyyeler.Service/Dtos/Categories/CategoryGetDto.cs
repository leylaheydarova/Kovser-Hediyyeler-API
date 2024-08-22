using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Service.Dtos.Categories
{
    public record CategoryGetDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
