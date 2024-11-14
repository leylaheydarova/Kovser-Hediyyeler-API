using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Departments.Recover
{
    public class RecoverDepartmentCommandRequest:RecoverCommandRequest, IRequest<RecoverDepartmentCommandResponse>
    {
    }
}
