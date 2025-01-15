using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Categories;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Categories.Update.TotalUpdate
{
    public class UpdateTotalCategoryCommandHandler : IRequestHandler<UpdateTotalCategoryCommandRequest, UpdateTotalCategoryCommandResponse>
    {
        readonly ICategoryService _service;

        public UpdateTotalCategoryCommandHandler(ICategoryService service)
        {
            _service = service;
        }

        public async Task<UpdateTotalCategoryCommandResponse> Handle(UpdateTotalCategoryCommandRequest request, CancellationToken cancellationToken)
        {
           
            _service.UpdateTotalCategoryAsync(request.Dto, request.Id)
            return new UpdateTotalCategoryCommandResponse
            {
                Message = "Kateqoriya məlumatları uğurla yeniləndi"
            };
        }
    }
}
