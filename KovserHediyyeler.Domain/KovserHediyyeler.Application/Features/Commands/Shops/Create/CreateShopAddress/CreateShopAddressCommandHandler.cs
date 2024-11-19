using KovserHediyyeler.Application.Repositories.Addresses;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Shops.Create.CreateShopAddress
{
    public class CreateShopAddressCommandHandler : IRequestHandler<CreateShopAddressCommandRequest, CreateShopAddressCommandResponse>
    {
        readonly IAddressWriteRepository _repository;

        public CreateShopAddressCommandHandler(IAddressWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateShopAddressCommandResponse> Handle(CreateShopAddressCommandRequest request, CancellationToken cancellationToken)
        {
            Address address = new Address
            {
                City = request.Dto.City,
                Region = request.Dto.Region,
                District = request.Dto.District == null ? "" : request.Dto.District,
                Street = request.Dto.Street,
                Home = request.Dto.Home,
                PostalCode = request.Dto.PostalCode,
                IsCurrentAddress = request.Dto.IsCurrentAddress,
                ShopID = Guid.Parse(request.ShopId)
            };

            await _repository.AddAsync(address);
            await _repository.SaveAsync();

            return new CreateShopAddressCommandResponse
            {
                StatusCode = 201,
                Message = "Mağaza ünvanı uğurla əlavə edilmişdir!"
            };
        }
    }
}
