using KovserHediyyeler.Application.Repositories.Files;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.Files
{
    public class InvoiceFileWriteRepository : WriteRepository<InvoiceFile>, IInvoceFileWriteRepository
    {
        public InvoiceFileWriteRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
