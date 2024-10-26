using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Features.Queries.Categories.GetAll.GetAllAbstractParents
{
    public class GetAllTopParentsQueryRequest:GetAllQueryRequest, IRequest<GetAllTopParentsQueryResponse>
    {
    }
}
