using KovserHedieyyeler.Application.DTOs.Addresses;
using KovserHedieyyeler.Application.DTOs.Shops;
using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.DTOs.Employees;
using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Addresses;
using KovserHediyyeler.Application.Repositories.Shops;
using KovserHediyyeler.Domain.Enums;
using KovserHediyyeler.Domain.Models;

namespace KovserHediyyeler.Persistence.Services
{
    public class ShopService : IShopService
    {
        readonly IShopReadRepository _shopReadRepository;
        readonly IShopWriteRepository _shopWriteRepository;
        readonly IAddressReadRepository _addressReadRepository;
        readonly IAddressWriteRepository _addressWriteRepository;

        public ShopService(IShopReadRepository shopReadRepository, IShopWriteRepository shopWriteRepository, IAddressReadRepository addressReadRepository, IAddressWriteRepository addressWriteRepository)
        {
            _shopReadRepository = shopReadRepository;
            _shopWriteRepository = shopWriteRepository;
            _addressReadRepository = addressReadRepository;
            _addressWriteRepository = addressWriteRepository;
        }

        public async Task CreateShopAddressAsync(AddressCommandDto dto, Guid ShopId)
        {
            var shop = await _shopReadRepository.GetWhereAsync(sh => sh.ID == ShopId && !sh.isDeleted, false);
            if (shop == null) throw new NotFoundException("mağaza");
            Address address = new Address
            {
                City = dto.City,
                Region = dto.Region,
                District = dto.District == null ? "" : dto.District,
                Street = dto.Street,
                Home = dto.Home,
                PostalCode = dto.PostalCode,
                IsCurrentAddress = dto.IsCurrentAddress,
                ShopID = shop.ID
            };

            await _addressWriteRepository.AddAsync(address);
            await _addressWriteRepository.SaveAsync();
        }

        public async Task CreateShopAsync(ShopPostDto dto)
        {
            using var transaction = await _shopWriteRepository.BeginTransactionAsync();
            try
            {
                Shop shop = new Shop
                {
                    ID = Guid.NewGuid(),
                    Name = dto.Name,
                    Description = dto.Description,
                    Phone = dto.Phone,
                };

                foreach (var addressDto in dto.Addresses)
                {
                    Address address = new Address
                    {
                        ID = Guid.NewGuid(),
                        City = addressDto.City,
                        Region = addressDto.Region,
                        District = addressDto.District == null ? " " : addressDto.District,
                        Street = addressDto.Street,
                        Home = addressDto.Home,
                        PostalCode = addressDto.PostalCode,
                        IsCurrentAddress = addressDto.IsCurrentAddress,
                        ShopID = shop.ID
                    };
                    //shop.Addresses.Add(address);
                    await _addressWriteRepository.AddAsync(address);
                }
                await _shopWriteRepository.AddAsync(shop);
                await _shopWriteRepository.SaveAsync();
                await _addressWriteRepository.SaveAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task DeleteTemporarilyShopAsync(Guid id)
        {
            using var transaction = await _shopWriteRepository.BeginTransactionAsync();
            try
            {
                Shop shop = await _readRepository.GetWhereAsync(sh => !sh.isDeleted && sh.ID == id, true, "Addresses");
                if (shop == null) throw new NotFoundException("mağaza");
                foreach (var address in shop.Addresses)
                {
                    _addressWriteRepository.DeleteTemporarily(address);
                }
                _shopWriteRepository.DeleteTemporarily(shop);
                await _shopWriteRepository.SaveAsync();
                await _addressWriteRepository.SaveAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<List<AddressGetDto>> GetAllShopAddressesAsync(int page, int size, Guid ShopId)
        {
            var query = _addressReadRepository.GetAllWhere(x => !x.isDeleted && x.ShopID == ShopId, false);
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

        public async Task<List<ShopGetAllDto>> GetAllShopsAsync(int page, int size)
        {
            var query = _shopReadRepository.GetAllWhere(x => !x.isDeleted, false, "Addresses");
            int totalCount = query.Count();
            List<ShopGetAllDto> dtos = new List<ShopGetAllDto>();
            dtos = await query.Skip(page * size)
                .Take(size)
                .Select(x => new ShopGetAllDto
                {
                    Id = x.ID.ToString(),
                    Name = x.Name,
                    Description = x.Description,
                    Phone = x.Phone,
                    City = x.Addresses.FirstOrDefault(ad => ad.IsCurrentAddress && ad.ShopID == x.ID).GetCity
                }).ToListAsync();
            return dtos;
        }

        public async Task<ShopGetSingleDto> GetSingleShopAsync(Guid id)
        {
            Shop shop = await _shopReadRepository.GetWhereAsync(x => !x.isDeleted && x.ID == id, false, "Employees.Position", "Addresses"); //add Products to include 

            if (shop == null) throw new NotFoundException("mağaza");

            var address = shop.Addresses.FirstOrDefault(a => a.IsCurrentAddress && !a.isDeleted);

            ShopGetSingleDto dto = new ShopGetSingleDto
            {
                Id = shop.ID.ToString(),
                Name = shop.Name,
                Phone = shop.Phone,
                Description = shop.Description,
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
                },
                Employees = shop.Employees.Select(e => new EmployeeGetAllDto
                {
                    Id = e.ID.ToString(),
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    PositionName = e.Position.Status
                }).ToList()
            };
            return dto;
        }

        public async Task RecoverShopDataAsync(Guid id)
        {
            using var transaction = await _shopWriteRepository.BeginTransactionAsync();
            try
            {
                Shop shop = await _readRepository.GetWhereAsync(sh => sh.isDeleted && sh.ID == id, true, "Addresses");
                if (shop == null) throw new NotFoundException("mağaza");
                foreach (var address in shop.Addresses)
                {
                    _addressWriteRepository.RecoverData(address);
                }
                _shopWriteRepository.RecoverData(shop);
                await _shopWriteRepository.SaveAsync();
                await _addressWriteRepository.SaveAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task RemovePermanentlyShopAddressAsync(Guid id)
        {
            Address address = await _addressReadRepository.GetByIdAsync(id, true);
            if (address == null) throw new NotFoundException("ünvan");
            _addressWriteRepository.RemovePermanently(address);
            await _addressWriteRepository.SaveAsync();
        }

        public async Task RemovePermanentlyShopAsync(Guid id)
        {
            using var transaction = await _shopWriteRepository.BeginTransactionAsync();
            try
            {
                Shop shop = await _shopReadRepository.GetByIdAsync(id, true, "Addresses");
                if (shop == null) throw new NotFoundException("mağaza");
                foreach (var address in shop.Addresses)
                {
                    _addressWriteRepository.RemovePermanently(address);
                }
                _shopWriteRepository.RemovePermanently(shop);
                await _shopWriteRepository.SaveAsync();
                await _addressWriteRepository.SaveAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task UpdateShopAddressAsync(AddressUpdateDto dto, Guid AddressId, Guid ShopId)
        {
            Address address = await _addressReadRepository.GetWhereAsync(a => !a.isDeleted && a.ID == AddressId && a.ShopID == ShopId, true);
            if (address == null) throw new NotFoundException("ünvan");
            address.City = dto.City is not null ? (City)dto.City : address.City;
            address.Region = dto.Region is not null ? dto.Region : address.Region;
            address.District = dto.District is not null ? dto.District : "";
            address.Street = dto.Street is not null ? dto.Street : address.Street;
            address.Home = dto.Home is not null ? dto.Home : address.Home;
            address.PostalCode = dto.PostalCode is not null ? dto.PostalCode : address.PostalCode;
            address.IsCurrentAddress = dto.IsCurrentAddress is not null ? (bool)dto.IsCurrentAddress : address.isDeleted;

            _addressWriteRepository.Update(address);
            await _addressWriteRepository.SaveAsync();
        }

        public async Task UpdateShopAsync(ShopPatchDto dto, Guid id)
        {
            Shop shop = await _shopReadRepository.GetWhereAsync(sh => !sh.isDeleted && sh.ID == id, true);
            if (shop == null) throw new NotFoundException("mağaza"); ;
            shop.Name = dto.Name is not null ? dto.Name : shop.Name;
            shop.Description = dto.Description is not null ? dto.Description : shop.Description;
            shop.Phone = dto.Phone is not null ? dto.Phone : shop.Phone;

            _shopWriteRepository.Update(shop);
            await _shopWriteRepository.SaveAsync();
        }

        public async Task UpdateTotalShopAsync(ShopPutDto dto, Guid id)
        {
            Shop shop = await _shopReadRepository.GetWhereAsync(sh => !sh.isDeleted && sh.ID == id, true);
            if (shop == null) throw new NotFoundException("mağaza");
            shop.Name = dto.Name;
            shop.Description = dto.Description;
            shop.Phone = dto.Phone;

            _shopWriteRepository.Update(shop);
            await _shopWriteRepository.SaveAsync();
        }
    }
}
