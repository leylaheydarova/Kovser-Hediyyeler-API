using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHedieyyeler.Application.Features.Commands.Categories.Delete.Permanently;
using KovserHedieyyeler.Application.Repositories.Abstractions.Categories;
using KovserHediyyeler.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                StatusCode = 200,
                Message = "Kateqoriya müvəqqəti silindi!"
            };
        }
    }
}
