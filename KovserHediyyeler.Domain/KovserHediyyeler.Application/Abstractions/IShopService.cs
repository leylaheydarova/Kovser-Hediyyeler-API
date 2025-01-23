using KovserHedieyyeler.Application.DTOs.Addresses;
using KovserHedieyyeler.Application.DTOs.Shops;

namespace KovserHediyyeler.Application.Abstractions
{
    public interface IShopService
    {
        //Commands
        public Task CreateShopAsync(ShopPostDto dto);
        public Task CreateShopAddressAsync(AddressCommandDto dto, Guid ShopId);
        public Task DeleteTemporarilyShopAsync(Guid id);
        public Task RecoverShopDataAsync(Guid id);
        public Task RemovePermanentlyShopAsync(Guid id);
        public Task RemovePermanentlyShopAddressAsync(Guid id);
        public Task UpdateShopAsync(ShopPatchDto dto, Guid id);
        public Task UpdateTotalShopAsync(ShopPutDto dto, Guid id);
        public Task UpdateShopAddressAsync(AddressUpdateDto dto, Guid AddressId, Guid ShopId);

        //Queries
        public Task<ShopGetSingleDto> GetSingleShopAsync(Guid id);
        public Task<List<ShopGetAllDto>> GetAllShopsAsync(int page, int size);
        public Task<List<AddressGetDto>> GetAllShopAddressesAsync(int page, int size, Guid ShopId);
    }
}
