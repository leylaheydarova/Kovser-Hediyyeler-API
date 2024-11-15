using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Categories;
using KovserHediyyeler.Domain.Models;
using MediatR;
namespace KovserHedieyyeler.Application.Features.Commands.Categories.Delete.Temporarily
{
    public class DeleteTemporarilyCategoryCommandHandler : IRequestHandler<DeleteTemporarilyCategoryCommandRequest, DeleteTemporarilyCategoryCommandResponse>
    {
        readonly ICategoryReadRepository _readRepository;
        readonly ICategoryWriteRepository _writeRepository;

        public DeleteTemporarilyCategoryCommandHandler(ICategoryReadRepository readRepository, ICategoryWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<DeleteTemporarilyCategoryCommandResponse> Handle(DeleteTemporarilyCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category category = await _readRepository.GetWhereAsync(x => !x.isDeleted && x.ID == Guid.Parse(request.Id), true);
            if (category == null) throw new CategoryNotFoundException();

            _writeRepository.DeleteTemporarily(category);
            await _writeRepository.SaveAsync();

            return new DeleteTemporarilyCategoryCommandResponse
            {
                Message = "Kateqoriya müvəqqəti silindi!"
            };
        }
    }
}
