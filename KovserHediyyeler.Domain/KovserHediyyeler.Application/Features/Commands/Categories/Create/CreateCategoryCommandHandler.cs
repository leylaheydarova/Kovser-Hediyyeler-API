using KovserHedieyyeler.Application.Exceptions.BadRequestExceptions;
using KovserHediyyeler.Application.Repositories.Categories;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Categories.Create
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
    {
        readonly ICategoryReadRepository _readRepository;
        readonly ICategoryWriteRepository _writeRepository;

        public CreateCategoryCommandHandler(ICategoryReadRepository readRepository, ICategoryWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category category = new Category
            {
                Name = request.Dto.Name,
                ParentId = request.Dto.ParentId,
                ParentCategory = await _readRepository.GetWhereAsync(x => !x.isDeleted && x.ID == request.Dto.ParentId, true)
            };
            if (category == null) throw new BadRequestException();
            _writeRepository.AddAsync(category);
            await _writeRepository.SaveAsync();

            return new CreateCategoryCommandResponse
            {
                StatusCode = 201,
                Message = "Kateqoriya uğurla əlavə olundu!"
            };
        }
    }
}
