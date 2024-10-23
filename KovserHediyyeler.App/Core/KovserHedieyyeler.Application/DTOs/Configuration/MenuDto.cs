using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.DTOs.Configuration
{
    public class MenuDto
    {
        public string Name { get; set; }
        public List<Action> Actions { get; set; } = new();
    }
}
