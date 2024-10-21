using KovserHedieyyeler.Application.Repositories.Abstractions.Addresses;
using KovserHedieyyeler.Application.Repositories.Abstractions.Shops;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Shops.Create.CreateShop
{
    public class CreateShopCommandHandler : IRequestHandler<CreateShopCommandRequest, CreateShopCommandResponse>
    {
        readonly IShopWriteRepository _shopWriteRepository;
        readonly IAddressWriteRepository _addressWriteRepository;

        public CreateShopCommandHandler(IShopWriteRepository shopWriteRepository, IAddressWriteRepository addressWriteRepository)
        {
            _shopWriteRepository = shopWriteRepository;
            _addressWriteRepository = addressWriteRepository;
        }

        public async Task<CreateShopCommandResponse> Handle(CreateShopCommandRequest request, CancellationToken cancellationToken)
        {
            Shop shop = new Shop
            {
                ID = Guid.NewGuid(),
                Name = request.Dto.Name,
                Description = request.Dto.Description,
                Phone = request.Dto.Phone,
            };



            foreach (var addressDto in request.Dto.Addresses)
            {
                Address address = new Address
                {
                    ID = Guid.NewGuid(),
                    City = addressDto.City,
                    Region = addressDto.Region,
                    Street = addressDto.Street,
                    Home = addressDto.Home,
                    PostalCode = addressDto.PostalCode,
                    IsCurrentAddress = addressDto.IsCurrentAddress,
                    ShopID = shop.ID
                };
                //shop.Addresses.Add(address);
                await _addressWriteRepository.AddAsync(address);
            }
            try
            {
                await _shopWriteRepository.AddAsync(shop);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            await _shopWriteRepository.SaveAsync();

            return new CreateShopCommandResponse
            {
                StatusCode = 201,
                Message = "Mağaza uğurla əlavə edilmişdir!"
            };
        }
    }
}
