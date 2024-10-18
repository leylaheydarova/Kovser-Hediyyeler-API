using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHedieyyeler.Application.Repositories.Interfaces.Categories;
using KovserHediyyeler.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
            Category category = await _readRepository.GetWhereAsync(x => x.ID.ToString() == request.Id, true);
            if (category == null) throw new CategoryNotFoundException();

            var query = _readRepository.GetAllWhere(child => !child.isDeleted && child.ParentId == Guid.Parse(request.Id), true).Include(c => c.ParentCategory);
            List<Category> categoryChilds = new List<Category>();
            categoryChilds = await query.ToListAsync();
            foreach (var categoryChild in categoryChilds)
            {
                if (categoryChild != null)
                {
                    categoryChild.ParentId = null;
                    _writeRepository.Update(categoryChild);
                }
            }

            await _writeRepository.SaveAsync();
            _writeRepository.RemovePermanently(category);
            await _writeRepository.SaveAsync();
            return new RemovePermanentlyCategoryCommandResponse
            {
                Message = "Kateqoriya uğurla silindi!"
            };
        }
    }
}
