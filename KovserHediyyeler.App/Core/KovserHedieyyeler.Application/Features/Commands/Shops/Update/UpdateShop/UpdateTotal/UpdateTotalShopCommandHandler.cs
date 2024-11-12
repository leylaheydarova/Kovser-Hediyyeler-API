using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHedieyyeler.Application.Repositories.Abstractions.Shops;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Shops.Update.UpdateShop.UpdateTotal
{
    public class UpdateTotalShopCommandHandler : IRequestHandler<UpdateTotalShopCommandRequest, UpdateTotalShopCommandResponse>
    {
        IShopReadRepository _readRepository;
        IShopWriteRepository _writeRepository;

        public UpdateTotalShopCommandHandler(IShopReadRepository readRepository, IShopWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<UpdateTotalShopCommandResponse> Handle(UpdateTotalShopCommandRequest request, CancellationToken cancellationToken)
        {
            KovserHediyyeler.Domain.Models.Shop shop = await _readRepository.GetWhereAsync(sh => !sh.isDeleted && sh.ID.ToString() == request.Id, true);
            if (shop == null) throw new ShopNotFoundException();
            shop.Name = request.Dto.Name;
            shop.Description = request.Dto.Description;
            shop.Phone = request.Dto.Phone;

            _writeRepository.Update(shop);
            await _writeRepository.SaveAsync();

            return new UpdateTotalShopCommandResponse
            {
                Message = "Mağaza məlumatları uğurla yeniləndi"
            };
        }
    }
}
