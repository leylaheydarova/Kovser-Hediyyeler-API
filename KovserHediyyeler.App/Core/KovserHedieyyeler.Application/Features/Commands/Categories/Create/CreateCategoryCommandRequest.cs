using KovserHedieyyeler.Application.DTOs.Categories;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Categories.Create
{
    public class CreateCategoryCommandRequest:CreateCommandRequest<CategoryCommandDto>, IRequest<CreateCategoryCommandResponse>
    {
    }
}
