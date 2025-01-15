using KovserHediyyeler.Application.Abstractions;
using MediatR;
namespace KovserHedieyyeler.Application.Features.Commands.Categories.Delete.Temporarily
{
    public class DeleteTemporarilyCategoryCommandHandler : IRequestHandler<DeleteTemporarilyCategoryCommandRequest, DeleteTemporarilyCategoryCommandResponse>
    {
        readonly ICategoryService _service;

        public DeleteTemporarilyCategoryCommandHandler(ICategoryService service)
        {
            _service = service;
        }

        public async Task<DeleteTemporarilyCategoryCommandResponse> Handle(DeleteTemporarilyCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.DeleteTemporarilyCategoryAsync(request.Id);

            return new DeleteTemporarilyCategoryCommandResponse
            {
                Message = "Kateqoriya müvəqqəti silindi!"
            };
        }
    }
}
