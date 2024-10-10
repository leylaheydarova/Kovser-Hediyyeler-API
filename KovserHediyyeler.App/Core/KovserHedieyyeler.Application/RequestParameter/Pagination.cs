using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.RequestParameter
{
    public record Pagination
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } 
    }
}
