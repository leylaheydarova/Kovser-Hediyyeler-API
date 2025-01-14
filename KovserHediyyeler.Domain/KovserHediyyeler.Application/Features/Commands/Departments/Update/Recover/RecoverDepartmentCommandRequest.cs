using KovserHedieyyeler.Application.Features.Commands;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Departments.Update.Recover
{
    public class RecoverDepartmentCommandRequest : RecoverCommandRequest, IRequest<RecoverDepartmentCommandResponse>
    {
    }
}
