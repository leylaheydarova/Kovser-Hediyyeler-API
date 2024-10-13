using KovserHedieyyeler.Application.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Features.Queries
{
    public class GetAllQueryResponse<T> where T : class
    {
        public List<T> Dtos { get; set; }
        public int TotalCount { get; set; }
    }
}
