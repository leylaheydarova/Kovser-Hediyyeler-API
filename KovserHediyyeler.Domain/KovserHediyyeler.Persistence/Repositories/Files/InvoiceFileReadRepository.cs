using KovserHediyyeler.Application.Repositories.Files;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.Files
{
    public class InvoiceFileReadRepository : ReadRepository<InvoiceFile>, IInvoceFileReadRepository
    {
        public InvoiceFileReadRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
