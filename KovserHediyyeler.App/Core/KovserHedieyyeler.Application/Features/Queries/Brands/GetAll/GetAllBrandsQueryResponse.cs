using KovserHedieyyeler.Application.DTOs.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Features.Queries.Brands.GetAll
{
    public class GetAllBrandsQueryResponse
    {
        public List<BrandGetDto> Dtos { get; set; } = new List<BrandGetDto>();
        public int TotalCount { get; set; }
    }
}
