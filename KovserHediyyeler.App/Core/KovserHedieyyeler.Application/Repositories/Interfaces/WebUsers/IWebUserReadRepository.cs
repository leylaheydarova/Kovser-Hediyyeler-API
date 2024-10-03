using KovserHediyyeler.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Repositories.Abstractions.WebUsers
{
    public interface IWebUserReadRepository:IIdentityReadRepository<WebUser>
    {
        
    }
}
