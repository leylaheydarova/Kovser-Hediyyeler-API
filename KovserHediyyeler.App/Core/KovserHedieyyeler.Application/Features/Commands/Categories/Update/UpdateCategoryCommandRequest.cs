using KovserHedieyyeler.Application.DTOs.Categories;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Categories.Update
{
    public class UpdateCategoryCommandRequest:UpdateCommandRequest<CategoryCommandDto>, IRequest<UpdateCategoryCommandResponse>
    {
    }
}
