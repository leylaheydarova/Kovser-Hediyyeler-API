using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Addresses;
using KovserHediyyeler.Application.Repositories.Shops;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Shops.Update.Recover
{
    public class RecoverShopCommandHandler : IRequestHandler<RecoverShopCommandRequest, RecoverShopCommandResponse>
    {
        IShopReadRepository _readRepository;
        IShopWriteRepository _writeRepository;
        IAddressWriteRepository _addressWriteRepository;

        public RecoverShopCommandHandler(IShopReadRepository readRepository, IShopWriteRepository writeRepository, IAddressWriteRepository addressWriteRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _addressWriteRepository = addressWriteRepository;
        }

        public async Task<RecoverShopCommandResponse> Handle(RecoverShopCommandRequest request, CancellationToken cancellationToken)
        {
            Shop shop = await _readRepository.GetWhereAsync(sh => sh.isDeleted && sh.ID.ToString() == request.Id, true);
            if (shop == null) throw new NotFoundException("mağaza");
            foreach (var address in shop.Addresses)
            {
                _addressWriteRepository.RecoverData(address);
            }
            _writeRepository.RecoverData(shop);
            await _writeRepository.SaveAsync();

            return new RecoverShopCommandResponse()
            {
                Message = "Mağaza məlumatları uğurla bərpa edilmişdir!"
            };
        }
    }
}
