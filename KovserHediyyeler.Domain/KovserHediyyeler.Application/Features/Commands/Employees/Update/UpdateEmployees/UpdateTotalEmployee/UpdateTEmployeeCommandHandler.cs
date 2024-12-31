using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Employees;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Employees.Update.UpdateEmployees.UpdateTotalEmployee
{
    public class UpdateTEmployeeCommandHandler : IRequestHandler<UpdateTEmployeeCommandRequest, UpdateTEmployeeCommandResponse>
    {
        readonly IEmployeeReadRepository _readRepository;
        readonly IEmployeeWriteRepository _writeRepository;

        public UpdateTEmployeeCommandHandler(IEmployeeReadRepository readRepository, IEmployeeWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<UpdateTEmployeeCommandResponse> Handle(UpdateTEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            Employee employee = await _readRepository.GetWhereAsync(emp => !emp.isDeleted && emp.ID.ToString() == request.Id, true);
            if (employee == null) throw new NotFoundException("işçi");
            employee.FirstName = request.Dto.FirstName;
            employee.LastName = request.Dto.LastName;
            employee.Phone = request.Dto.Phone;
            employee.DepartmentID = request.Dto.DepartmentID;
            employee.ShopID = request.Dto.ShopID;
            employee.isRemote = request.Dto.isRemote;
            employee.PositionID = request.Dto.PositionID;

            _writeRepository.Update(employee);
            await _writeRepository.SaveAsync();
            return new UpdateTEmployeeCommandResponse
            {
                Message = "İşçi məlumatları uğurla yeniləndi"
            };
        }
    }
}
