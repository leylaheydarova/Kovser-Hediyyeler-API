using Azure.Core;
using KovserHedieyyeler.Application.DTOs.Addresses;
using KovserHedieyyeler.Application.DTOs.Employees;
using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.DTOs.Employees;
using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories;
using KovserHediyyeler.Application.Repositories.Addresses;
using KovserHediyyeler.Application.Repositories.Employees;
using KovserHediyyeler.Domain.Enums;
using KovserHediyyeler.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace KovserHediyyeler.Persistence.Services
{
    public class EmployeeService : IEmployeeService
    {
        readonly IEmployeeReadRepository _employeeReadRepository;
        readonly IEmployeeWriteRepository _employeeWriteRepository;
        readonly IAddressReadRepository _addressReadRepository;
        readonly IAddressWriteRepository _addressWriteRepository;

        public EmployeeService(IEmployeeReadRepository employeeReadRepository, IEmployeeWriteRepository employeeWriteRepository, IAddressReadRepository addressReadRepository, IAddressWriteRepository addressWriteRepository)
        {
            _employeeReadRepository = employeeReadRepository;
            _employeeWriteRepository = employeeWriteRepository;
            _addressReadRepository = addressReadRepository;
            _addressWriteRepository = addressWriteRepository;
        }

        public async Task CreateEmployeeAsync(EmployeePostDto dto)
        {

            using var transaction = await _employeeWriteRepository.BeginTransactionAsync();
            try
            {
                Employee employee = new Employee
                {
                    ID = Guid.NewGuid(),
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Phone = dto.Phone,
                    DepartmentID = dto.DepartmentID,
                    ShopID = dto.ShopID,
                    isRemote = dto.isRemote,
                    PositionID = dto.PositionID
                };

                foreach (var addressDto in dto.Addresses)
                {
                    Address address = new Address
                    {
                        ID = Guid.NewGuid(),
                        City = addressDto.City,
                        Region = addressDto.Region,
                        District = addressDto.District == null ? "" : addressDto.District,
                        Street = addressDto.Street,
                        Home = addressDto.Home,
                        PostalCode = addressDto.PostalCode,
                        IsCurrentAddress = addressDto.IsCurrentAddress,
                        EmployeeID = employee.ID
                    };
                    await _addressWriteRepository.AddAsync(address);
                }
                await _employeeWriteRepository.AddAsync(employee);
                await _addressWriteRepository.SaveAsync();
                await _employeeWriteRepository.SaveAsync();
                await transaction.CommitAsync();
            }

            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task CreateEmployeeAddressAsync(AddressCommandDto dto, Guid EmployeeId)
        {
            var employee = await _employeeReadRepository.GetWhereAsync(e => e.ID == EmployeeId && !e.isDeleted, false);
            if (employee == null) throw new NotFoundException("işçi");
            Address address = new Address
            {
                City = dto.City,
                Region = dto.Region,
                District = dto.District == null ? "" : dto.District,
                Street = dto.Street,
                Home = dto.Home,
                PostalCode = dto.PostalCode,
                IsCurrentAddress = dto.IsCurrentAddress,
                EmployeeID = employee.ID
            };

            await _addressWriteRepository.AddAsync(address);
            await _addressWriteRepository.SaveAsync();
        }

        public async Task RemovePermanentlyEmployeeAsync(Guid id)
        {
            using var transaction = await _employeeWriteRepository.BeginTransactionAsync();
            try
            {
                Employee employee = await _employeeReadRepository.GetWhereAsync(x => x.ID == id, true, "Addresses");
                if (employee == null) throw new NotFoundException("işçi");
                if (employee.Addresses.Count() > 0)
                {
                    foreach (var address in employee.Addresses)
                    {
                        _addressWriteRepository.RemovePermanently(address);
                    }
                }
                _employeeWriteRepository.RemovePermanently(employee);
                await _employeeWriteRepository.SaveAsync();
                await _addressWriteRepository.SaveAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task RemovePermanentlyEmployeeAddressAsync(Guid id)
        {
            Address address = await _addressReadRepository.GetWhereAsync(x => x.ID == id, true);
            if (address == null) throw new NotFoundException("ünvan");
            _addressWriteRepository.RemovePermanently(address);
            await _addressWriteRepository.SaveAsync();
        }

        public async Task DeleteTemporarilyEmployeeAsync(Guid id)
        {
            using var transaction = await _employeeWriteRepository.BeginTransactionAsync();
            try
            {
                Employee employee = await _employeeReadRepository.GetWhereAsync(x => x.ID == id, true, "Addresses");
                if (employee == null) throw new NotFoundException("işçi");
                if (employee.Addresses.Count() > 0)
                {
                    foreach (var address in employee.Addresses)
                    {
                        _addressWriteRepository.DeleteTemporarily(address);
                    }
                }
                _employeeWriteRepository.DeleteTemporarily(employee);
                await _employeeWriteRepository.SaveAsync();
                await _addressWriteRepository.SaveAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task RecoverEmployeeDataAsync(Guid id)
        {
            using var transaction = await _employeeWriteRepository.BeginTransactionAsync();
            try
            {
                Employee employee = await _employeeReadRepository.GetWhereAsync(x => x.ID == id, true, "Addresses");
                if (employee == null) throw new NotFoundException("işçi");
                if (employee.Addresses.Count() > 0)
                {
                    foreach (var address in employee.Addresses)
                    {
                        _addressWriteRepository.RecoverData(address);
                    }
                }
                _employeeWriteRepository.RecoverData(employee);
                await _employeeWriteRepository.SaveAsync();
                await _addressWriteRepository.SaveAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task UpdateEmployeeAddressAsync(Guid AddressId, Guid EmployeeId, AddressUpdateDto dto)
        {
            Address address = await _addressReadRepository.GetWhereAsync(a => !a.isDeleted && a.ID == AddressId && a.EmployeeID == EmployeeId, true);
            if (address == null) throw new NotFoundException("ünvan");
            address.City = dto.City != null ? (City)dto.City : address.City;
            address.Region = dto.Region != null ? dto.Region : address.Region;
            address.District = dto.District != null ? dto.District : "";
            address.Street = dto.Street != null ? dto.Street : address.Street;
            address.Home = dto.Home != null ? dto.Home : address.Home;
            address.PostalCode = dto.PostalCode != null ? dto.PostalCode : address.PostalCode;
            address.IsCurrentAddress = dto.IsCurrentAddress != null ? (bool)dto.IsCurrentAddress : address.IsCurrentAddress;

            _addressWriteRepository.Update(address);
            await _addressWriteRepository.SaveAsync();
        }

        public async Task UpdateEmployeeAsync(Guid EmployeeId, EmployeePatchDto dto)
        {
            Employee employee = await _employeeReadRepository.GetWhereAsync(emp => !emp.isDeleted && emp.ID == EmployeeId, true);
            if (employee == null) throw new NotFoundException("işçi");
            employee.FirstName = dto.FirstName != null ? dto.FirstName : employee.FirstName;
            employee.LastName = dto.LastName != null ? dto.LastName : employee.LastName;
            employee.Phone = dto.Phone != null ? dto.Phone : employee.Phone;
            employee.DepartmentID = dto.DepartmentID != null ? (Guid)dto.DepartmentID : employee.DepartmentID;
            employee.ShopID = dto.ShopID != null ? (Guid)dto.ShopID : employee.ShopID;
            employee.isRemote = dto.isRemote != null ? (bool)dto.isRemote : employee.isRemote;
            employee.PositionID = dto.PositionID != null ? (Guid)dto.PositionID : employee.PositionID;

            _employeeWriteRepository.Update(employee);
            await _employeeWriteRepository.SaveAsync();
        }

        public async Task UpdateTotalEmployeeAsync(Guid EmployeeId, EmployeePutDto dto)
        {
            Employee employee = await _employeeReadRepository.GetWhereAsync(emp => !emp.isDeleted && emp.ID == EmployeeId, true);
            if (employee == null) throw new NotFoundException("işçi");
            employee.FirstName = dto.FirstName;
            employee.LastName = dto.LastName;
            employee.Phone = dto.Phone;
            employee.DepartmentID = dto.DepartmentID;
            employee.ShopID = dto.ShopID;
            employee.isRemote = dto.isRemote;
            employee.PositionID = dto.PositionID;

            _employeeWriteRepository.Update(employee);
            await _employeeWriteRepository.SaveAsync();
        }

        public async Task<EmployeeGetDto> GetSingleEmployeeAsync(Guid id)
        {
            Employee employee = await _employeeReadRepository.GetWhereAsync(x => !x.isDeleted && x.ID == id, false, "Addresses", "Position", "Shop", "Department");
            if (employee == null)
            {
                throw new NotFoundException("işçi");
            }
            var address = employee.Addresses.FirstOrDefault(ad => ad.IsCurrentAddress && !ad.isDeleted);
            EmployeeGetDto dto = new EmployeeGetDto
            {
                Id = employee.ID.ToString(),
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Phone = employee.Phone,
                isRemote = employee.isRemote,
                DepartmentName = employee.Department.Name,
                PositionName = employee.Position.Status,
                ShopName = employee.Shop.Name,
                Address = new AddressGetDto
                {
                    Id = address.ID.ToString(),
                    City = address.City.ToString(),
                    Region = address.Region,
                    District = address.District,
                    Street = address.Street,
                    Home = address.Home,
                    PostalCode = address.PostalCode,
                    IsCurrentAddress = address.IsCurrentAddress
                }
            };

            return dto;
        }

        public async Task<List<EmployeeGetAllDto>> GetAllEmployeesAsync(int page, int size)
        {
            var query = _employeeReadRepository.GetAllWhere(x => !x.isDeleted, false, "Position");
            int totalCount = query.Count();

            List<EmployeeGetAllDto> dtos = new List<EmployeeGetAllDto>();
            dtos = await query.Skip(page * size)
                .Take(size)
                .Select(e => new EmployeeGetAllDto
                {
                    Id = e.ID.ToString(),
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    PositionName = e.Position.Status
                }).ToListAsync();
            return dtos;
        }

        public async Task<List<AddressGetDto>> GetAllEmployeeAddressesAsync(int page, int size, Guid EmployeeId)
        {
            var query = _addressReadRepository.GetAllWhere(x => !x.isDeleted && x.EmployeeID == EmployeeId, false);
            List<AddressGetDto> dtos = new List<AddressGetDto>();
            dtos = await query.Skip(page * size)
                .Take(size)
                .Select(x => new AddressGetDto
                {
                    Id = x.ID.ToString(),
                    City = x.City.ToString(),
                    Region = x.Region,
                    District = x.District,
                    Street = x.Street,
                    Home = x.Home,
                    PostalCode = x.PostalCode,
                    IsCurrentAddress = x.IsCurrentAddress
                }).ToListAsync();
            return dtos;
        }
    }
}
