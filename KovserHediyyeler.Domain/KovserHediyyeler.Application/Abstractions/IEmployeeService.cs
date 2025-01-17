using KovserHedieyyeler.Application.DTOs.Addresses;
using KovserHedieyyeler.Application.DTOs.Employees;
using KovserHediyyeler.Application.DTOs.Employees;

namespace KovserHediyyeler.Application.Abstractions
{
    public interface IEmployeeService
    {
        //Commands
        Task CreateEmployeeAsync(EmployeePostDto dto);
        Task CreateEmployeeAddressAsync(AddressCommandDto dto, Guid EmployeeId);
        Task DeleteTemporarilyEmployeeAsync(Guid id);
        Task RecoverEmployeeDataAsync(Guid id);
        Task RemovePermanentlyEmployeeAsync(Guid id);
        Task RemovePermanentlyEmployeeAddressAsync(Guid id);
        Task UpdateEmployeeAddressAsync(Guid AddressId, Guid EmployeeId, AddressUpdateDto dto);
        Task UpdateEmployeeAsync(Guid EmployeeId, EmployeePatchDto dto);
        Task UpdateTotalEmployeeAsync(Guid EmployeeId, EmployeePutDto dto);

        //Queries
        Task<EmployeeGetDto> GetSingleEmployeeAsync(Guid id);
        Task<List<EmployeeGetAllDto>> GetAllEmployeesAsync(int page, int size);
        Task<List<AddressGetDto>> GetAllEmployeeAddressesAsync(int page, int size, Guid EmployeeId);
    }
}
