using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Service.Dtos.Departments
{
    public record DepartmentGetDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Instagram { get; set; }
        public string TikTok { get; set; }
        public string? Facebook { get; set; }
        public string? YouTube
        {
            get; set;
        }
    }
}
