using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Features.Queries.Brands.GetSingle
{
    public class GetSingleBrandQueryRequest:IRequest<GetSingleBrandQueryResponse>
    {
        public string Id { get; set; }
    }
}
