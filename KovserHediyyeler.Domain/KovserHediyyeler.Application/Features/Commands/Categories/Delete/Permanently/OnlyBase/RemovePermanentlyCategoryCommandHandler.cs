using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Categories.Delete.Permanently.OnlyBase
{
    public class RemovePermanentlyCategoryCommandHandler : IRequestHandler<RemovePermanentlyCategoryCommandRequest, RemovePermanentlyCategoryCommandResponse>
    {
        readonly ICategoryService _service;

        public RemovePermanentlyCategoryCommandHandler(ICategoryService service)
        {
            _service = service;
        }

        public async Task<RemovePermanentlyCategoryCommandResponse> Handle(RemovePermanentlyCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.RemovePermanentlyCategoryAsync(request.Id);
            return new RemovePermanentlyCategoryCommandResponse
            {
                Message = "Kateqoriya uğurla silindi!"
            };
        }
    }
}
