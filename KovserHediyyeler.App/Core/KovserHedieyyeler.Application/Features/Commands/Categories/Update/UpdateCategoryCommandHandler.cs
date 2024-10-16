using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHedieyyeler.Application.Repositories.Abstractions.Categories;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Categories.Update
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {
        readonly ICategoryReadRepository _readRepository;
        readonly ICategoryWriteRepository _writeRepository;

        public UpdateCategoryCommandHandler(ICategoryReadRepository readRepository, ICategoryWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category category = await _readRepository.GetWhereAsync(x => !x.isDeleted && x.ID == Guid.Parse(request.Id), true);
            if (category == null) throw new CategoryNotFoundException();
            category.Name = request.Dto.Name;
            category.ParentId = request.Dto.ParentId;
            
            _writeRepository.Update(category);
            await _writeRepository.SaveAsync();

            return new UpdateCategoryCommandResponse
            {
                Message = "Məlumatlar uğurla yeniləndi"
            };
        }
    }
}
