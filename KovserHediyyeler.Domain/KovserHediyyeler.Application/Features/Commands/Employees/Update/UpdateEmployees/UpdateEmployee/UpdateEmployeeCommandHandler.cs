using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Employees;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Employees.Update.UpdateEmployees.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommandRequest, UpdateEmployeeCommandResponse>
    {
        readonly IEmployeeReadRepository _readRepository;
        readonly IEmployeeWriteRepository _writeRepository;

        public UpdateEmployeeCommandHandler(IEmployeeReadRepository readRepository, IEmployeeWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<UpdateEmployeeCommandResponse> Handle(UpdateEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            Employee employee = await _readRepository.GetWhereAsync(emp => !emp.isDeleted && emp.ID.ToString() == request.Id, true);
            if (employee == null) throw new EmployeeNotFoundException();
            var dto = request.Dto;
            employee.FirstName = dto.FirstName != null ? dto.FirstName : employee.FirstName;
            employee.LastName = dto.LastName != null ? dto.LastName : employee.LastName;
            employee.Phone = dto.Phone != null ? dto.Phone : employee.Phone;
            employee.DepartmentID = dto.DepartmentID != null ? (Guid)dto.DepartmentID : employee.DepartmentID;
            employee.ShopID = dto.ShopID != null ? (Guid)dto.ShopID : employee.ShopID;
            employee.isRemote = dto.isRemote != null ? (bool)dto.isRemote : employee.isRemote;
            employee.PositionID = dto.PositionID != null ? (Guid)dto.PositionID : employee.PositionID;

            _writeRepository.Update(employee);
            await _writeRepository.SaveAsync();
            return new UpdateEmployeeCommandResponse
            {
                Message = "Məlumat uğurla yeniləndi!"
            };
        }
    }
}
