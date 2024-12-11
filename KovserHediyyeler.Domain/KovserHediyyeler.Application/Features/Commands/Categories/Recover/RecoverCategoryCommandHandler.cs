using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Categories;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Categories.Recover
{
    public class RecoverCategoryCommandHandler : IRequestHandler<RecoverCategoryCommandRequest, RecoverCategoryCommandResponse>
    {
        readonly ICategoryReadRepository _readRepository;
        readonly ICategoryWriteRepository _writeRepository;

        public RecoverCategoryCommandHandler(ICategoryReadRepository readRepository, ICategoryWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<RecoverCategoryCommandResponse> Handle(RecoverCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category category = await _readRepository.GetWhereAsync(c => c.isDeleted && c.ID.ToString() == request.Id, true);
            if (category == null) throw new NotFoundException("kateqoriya");
            _writeRepository.RecoverData(category);
            await _writeRepository.SaveAsync();
            return new RecoverCategoryCommandResponse
            {
                Message = "Kateqoriya məlumatları uğurla bərpa edilmişdir!"
            };
        }
    }
}
