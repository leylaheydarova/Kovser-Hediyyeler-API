using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Categories.Delete.Permanently.WithItsChild
{
    public class RemoveCategoryWithChildCommandHandler : IRequestHandler<RemoveCategoryWithChildCommandRequest, RemoveCategoryWithChildCommandResponse>
    {
        readonly ICategoryService _service;

        public RemoveCategoryWithChildCommandHandler(ICategoryService service)
        {
            _service = service;
        }

        public async Task<RemoveCategoryWithChildCommandResponse> Handle(RemoveCategoryWithChildCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.RemovePermanentlyCategoryWithItsChildsAsync(request.Id);
            return new RemoveCategoryWithChildCommandResponse
            {
                Message = "Kateqoriya və alt kateqoriyaları uğurla silindi!"
            };
        }
    }
}
