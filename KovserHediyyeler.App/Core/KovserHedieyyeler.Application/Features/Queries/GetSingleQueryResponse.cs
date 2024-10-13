using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Features.Queries
{
    public class GetSingleQueryResponse<T> where T : class
    {
        public T Dto { get; set; }
    }
}
