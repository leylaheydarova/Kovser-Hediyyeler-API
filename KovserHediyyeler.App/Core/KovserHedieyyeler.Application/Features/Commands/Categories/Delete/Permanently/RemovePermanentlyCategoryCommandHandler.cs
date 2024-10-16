using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHedieyyeler.Application.Repositories.Abstractions.Categories;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Categories.Delete.Permanently
{
    public class RemovePermanentlyCategoryCommandHandler : IRequestHandler<RemovePermanentlyCategoryCommandRequest, RemovePermanentlyCategoryCommandResponse>
    {
        readonly ICategoryReadRepository _readRepository;
        readonly ICategoryWriteRepository _writeRepository;

        public RemovePermanentlyCategoryCommandHandler(ICategoryReadRepository readRepository, ICategoryWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<RemovePermanentlyCategoryCommandResponse> Handle(RemovePermanentlyCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category category = await _readRepository.GetWhereAsync(x => !x.isDeleted && x.ID == Guid.Parse(request.Id), true);
            if (category == null) throw new CategoryNotFoundException();
            
            _writeRepository.RemovePermanently(category);
            await _writeRepository.SaveAsync();

            return new RemovePermanentlyCategoryCommandResponse
            {
                StatusCode = 200,
                Message = "Kateqoriya uğurla silindi!"
            };
        }
    }
}
