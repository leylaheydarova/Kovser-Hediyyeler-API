using KovserHedieyyeler.Application.Repositories.Abstractions.WebUsers;
using KovserHediyyeler.Domain.Models.Identity;
using KovserHediyyeler.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Persistence.Repositories.Concretes.WebUsers
{
    public class WebUserReadRepository : IdentityReadRepository<WebUser>, IWebUserReadRepository
    {
        public WebUserReadRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }

       
    }
}
