using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Categories.Create
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
    {
        readonly ICategoryService _service;

        public CreateCategoryCommandHandler(ICategoryService service)
        {
            _service = service;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.CreateCategoryAsync(request.Dto);

            return new CreateCategoryCommandResponse
            {
                StatusCode = 201,
                Message = "Kateqoriya uğurla əlavə olundu!"
            };
        }
    }
}
