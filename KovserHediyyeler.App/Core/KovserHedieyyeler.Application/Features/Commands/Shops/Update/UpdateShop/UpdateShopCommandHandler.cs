using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHedieyyeler.Application.Features.Commands.Shops.Update.Shop;
using KovserHedieyyeler.Application.Repositories.Abstractions.Shops;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Shops.Update
{
    public class UpdateShopCommandHandler : IRequestHandler<UpdateShopCommandRequest, UpdateShopCommandResponse>
    {
        IShopReadRepository _readRepository;
        IShopWriteRepository _writeRepository;

        public UpdateShopCommandHandler(IShopReadRepository readRepository, IShopWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<UpdateShopCommandResponse> Handle(UpdateShopCommandRequest request, CancellationToken cancellationToken)
        {
            KovserHediyyeler.Domain.Models.Shop shop = await _readRepository.GetWhereAsync(sh => !sh.isDeleted && sh.ID.ToString() == request.Id, true);
            if (shop == null) throw new ShopNotFoundException();
            shop.Name = request.Dto.Name;
            shop.Description = request.Dto.Description;
            shop.Phone = request.Dto.Phone;

            _writeRepository.Update(shop);
            await _writeRepository.SaveAsync();

            return new UpdateShopCommandResponse
            {
                Message = "Mağaza məlumatları uğurla yeniləndi"
            };

        }
    }
}
