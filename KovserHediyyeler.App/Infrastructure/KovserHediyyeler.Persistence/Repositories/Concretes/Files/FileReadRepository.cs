using KovserHedieyyeler.Application.Repositories.Interfaces.Files;
using KovserHediyyeler.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Persistence.Repositories.Concretes.Files
{
    public class FileReadRepository : ReadRepository<KovserHediyyeler.Domain.Models.File>, IFileReadRepository
    {
        public FileReadRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
