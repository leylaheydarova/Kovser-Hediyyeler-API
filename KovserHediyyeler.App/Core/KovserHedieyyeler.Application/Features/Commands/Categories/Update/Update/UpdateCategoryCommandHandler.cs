using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHedieyyeler.Application.Repositories.Interfaces.Categories;
using KovserHediyyeler.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Features.Commands.Categories.Update.UpdatePartly
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {
        ICategoryReadRepository _readRepository;
        ICategoryWriteRepository _writeRepository;

        public UpdateCategoryCommandHandler(ICategoryReadRepository readRepository, ICategoryWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category category = await _readRepository.GetWhereAsync(x => !x.isDeleted && x.ID.ToString() == request.Id, true);
            if (category == null) throw new CategoryNotFoundException();
            category.Name = request.Dto.Name != null ? request.Dto.Name : category.Name;
            category.ParentId = request.Dto.ParentId != null ? request.Dto.ParentId : category.ParentId;
            _writeRepository.Update(category);
            await _writeRepository.SaveAsync();
            return new UpdateCategoryCommandResponse
            {
                Message = "Məlumat uğurla yeniləndi!"
            };
        }
    }
}
