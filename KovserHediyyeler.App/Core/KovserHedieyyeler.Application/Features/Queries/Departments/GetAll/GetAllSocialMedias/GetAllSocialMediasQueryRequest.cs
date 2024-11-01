using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Features.Queries.Departments.GetAll.GetAllSocialMedias
{
    public class GetAllSocialMediasQueryRequest:IRequest<GetAllSocialMediasQueryResponse>
    {
        public string DepartmentId { get; set; }
    }
}
