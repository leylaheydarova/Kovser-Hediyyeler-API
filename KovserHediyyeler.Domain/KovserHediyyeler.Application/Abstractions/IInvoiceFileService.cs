using Microsoft.AspNetCore.Http;

namespace KovserHediyyeler.Application.Abstractions
{
    public interface IInvoiceFileService
    {
        Task<IFormFile> CreateInvoiceFileAsync(Guid OrderId);
    }
}
