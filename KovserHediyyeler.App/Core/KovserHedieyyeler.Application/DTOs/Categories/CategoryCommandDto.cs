using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.DTOs.Categories
{
    public class CategoryCommandDto
    {
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
    }
}
