using KovserHedieyyeler.Application.Repositories.Interfaces.Files;
using KovserHediyyeler.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Persistence.Repositories.Concretes.Files
{
    public class FileWriteRepository : WriteRepository<KovserHediyyeler.Domain.Models.File>, IFileWriteRepository
    {
        public FileWriteRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
