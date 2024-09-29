using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Repositories.Abstractions
{
    public interface IIdentityRepository<T> where T: IdentityUser<Guid>
    {
        DbSet<T> Table { get; }
    }
}
