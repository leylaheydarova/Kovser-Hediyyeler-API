using KovserHediyyeler.Application.Repositories.Files;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.Files
{
    public class FileWriteRepository : WriteRepository<Domain.Models.File>, IFileWriteRepository
    {
        public FileWriteRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
