using KovserHedieyyeler.Application.DTOs.Categories;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Categories.Update.TotalUpdate
{
    public class UpdateCategoryCommandRequest : UpdateCommandRequest<CategoryCommandDto>, IRequest<UpdateCategoryCommandResponse>
    {
    }
}
