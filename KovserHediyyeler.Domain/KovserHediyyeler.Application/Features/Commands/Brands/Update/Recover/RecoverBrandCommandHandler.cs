using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Brands.Update.Recover
{
    public class RecoverBrandCommandHandler : IRequestHandler<RecoverCategoryRequest, RecoverBrandCommandResponse>
    {
        readonly IBrandService _service;

        public RecoverBrandCommandHandler(IBrandService service)
        {
            _service = service;
        }

        public async Task<RecoverBrandCommandResponse> Handle(RecoverCategoryRequest request, CancellationToken cancellationToken)
        {
            await _service.RecoverDataAsync(request.Id);

            return new RecoverBrandCommandResponse
            {
                Message = "Brend məlumatları uğurla bərpa edilmişdir!"
            };

        }
    }
}
