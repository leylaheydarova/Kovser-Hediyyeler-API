using KovserHediyyeler.Application.Repositories.Files;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.Files
{
    public class FileReadRepository : ReadRepository<Domain.Models.File>, IFileReadRepository
    {
        public FileReadRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
