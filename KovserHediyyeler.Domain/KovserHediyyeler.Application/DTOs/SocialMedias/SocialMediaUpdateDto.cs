using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.DTOs.SocialMedias
{
    public class SocialMediaUpdateDto
    {
        public string? NickName { get; set; }
        public string? Name { get; set; }
        public string? URL { get; set; }
        public Guid? DepartmentID { get; set; }
    }
}
