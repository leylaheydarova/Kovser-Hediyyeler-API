using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Repositories.Categories;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Categories.Update.UpdatePartly
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {
        readonly ICategoryService _service;

        public UpdateCategoryCommandHandler(ICategoryService service)
        {
            _service = service;
        }

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.UpdateCategoryAsync(request.Dto, request.Id);
            return new UpdateCategoryCommandResponse
            {
                Message = "Məlumat uğurla yeniləndi!"
            };
        }
    }
}
