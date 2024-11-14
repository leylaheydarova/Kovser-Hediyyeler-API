using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Features.Commands.Categories.Delete.Temporarily
{
    public class DeleteTemporarilyCategoryCommandRequest:DeleteCommandRequest, IRequest<DeleteTemporarilyCategoryCommandResponse>
    {
    }
}
