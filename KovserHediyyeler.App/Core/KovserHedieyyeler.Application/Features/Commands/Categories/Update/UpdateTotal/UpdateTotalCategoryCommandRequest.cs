using KovserHedieyyeler.Application.DTOs.Categories;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Categories.Update.TotalUpdate
{
    public class UpdateTotalCategoryCommandRequest : UpdateCommandRequest<CategoryCommandDto>, IRequest<UpdateTotalCategoryCommandResponse>
    {
    }
}
