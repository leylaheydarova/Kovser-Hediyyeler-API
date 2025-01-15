using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Categories.Update.Recover
{
    public class RecoverCategoryCommandHandler : IRequestHandler<RecoverCategoryCommandRequest, RecoverCategoryCommandResponse>
    {
        readonly ICategoryService _service;

        public RecoverCategoryCommandHandler(ICategoryService service)
        {
            _service = service;
        }

        public async Task<RecoverCategoryCommandResponse> Handle(RecoverCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.RecoverCategoryDataAsync(request.Id);
            return new RecoverCategoryCommandResponse
            {
                Message = "Kateqoriya məlumatları uğurla bərpa edilmişdir!"
            };
        }
    }
}
