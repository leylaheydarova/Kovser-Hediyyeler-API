using KovserHedieyyeler.Application.RequestParameter;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Features.Queries.Brands.GetAll
{
    public class GetAllBrandsQueryRequest : IRequest<GetAllBrandsQueryResponse>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
