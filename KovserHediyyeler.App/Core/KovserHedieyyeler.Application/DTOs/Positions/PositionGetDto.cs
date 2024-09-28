using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.DTOs.Positions
{
    public record PositionGetDto
    {
        public string Id { get; set; }
        public string Status { get; set; }
    }
}
