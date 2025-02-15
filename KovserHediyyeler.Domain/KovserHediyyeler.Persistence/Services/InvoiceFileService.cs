using KovserHediyyeler.Application.Abstractions;
using Microsoft.AspNetCore.Http;

namespace KovserHediyyeler.Persistence.Services
{
    public class InvoiceFileService : IInvoiceFileService
    {
        public Task<IFormFile> CreateInvoiceFileAsync(Guid OrderId)
        {
            throw new NotImplementedException();
        }
    }
}
