using KovserHedieyyeler.Application.DTOs.Categories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Features.Commands.Categories.Update.UpdatePartly
{
    public class UpdatePartlyCategoryCommandRequest:UpdateCommandRequest<CategoryUpdateDto>, IRequest<UpdatePartlyCategoryCommandResponse>
    {
    }
}
