using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Shops;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Shops.Update.UpdateShop.Update
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
            var dto = request.Dto;
            shop.Name = dto.Name is not null ? dto.Name : shop.Name;
            shop.Description = dto.Description is not null ? dto.Description : shop.Description;
            shop.Phone = dto.Phone is not null ? dto.Phone : shop.Phone;

            _writeRepository.Update(shop);
            await _writeRepository.SaveAsync();

            return new UpdateShopCommandResponse
            {
                Message = "Mağaza məlumatları uğurla yeniləndi"
            };

        }
    }
}
