using KovserHedieyyeler.Application.Repositories.Abstractions.WebUsers;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Persistence.Repositories.Concretes.WebUsers
{
    public class WebUserWriteRepository : IdentityWriteRepository<WebUser>, IWebUserWriteRepository
    {
        private readonly KovserHediyyelerDbContext _context;
        public WebUserWriteRepository(KovserHediyyelerDbContext context) : base(context)
        {
            _context = context;
        }

        public bool DeleteTemporarily(WebUser webUser)
        {
            webUser.isDeleted = true;
            return _context.Entry(webUser).State == EntityState.Modified;
        }
    }
}