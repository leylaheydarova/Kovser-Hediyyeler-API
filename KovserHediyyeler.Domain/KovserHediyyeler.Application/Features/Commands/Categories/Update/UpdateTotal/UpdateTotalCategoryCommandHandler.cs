using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Categories;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Categories.Update.TotalUpdate
{
    public class UpdateTotalCategoryCommandHandler : IRequestHandler<UpdateTotalCategoryCommandRequest, UpdateTotalCategoryCommandResponse>
    {
        readonly ICategoryReadRepository _readRepository;
        readonly ICategoryWriteRepository _writeRepository;

        public UpdateTotalCategoryCommandHandler(ICategoryReadRepository readRepository, ICategoryWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<UpdateTotalCategoryCommandResponse> Handle(UpdateTotalCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category category = await _readRepository.GetWhereAsync(x => !x.isDeleted && x.ID == Guid.Parse(request.Id), true);
            if (category == null) throw new CategoryNotFoundException();
            category.Name = request.Dto.Name;
            category.ParentId = request.Dto.ParentId;

            _writeRepository.Update(category);
            await _writeRepository.SaveAsync();

            return new UpdateTotalCategoryCommandResponse
            {
                Message = "Kateqoriya məlumatları uğurla yeniləndi"
            };
        }
    }
}
