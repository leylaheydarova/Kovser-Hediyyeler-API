using KovserHediyyeler.Application.Repositories.Promotions;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Promotions.Delete
{
    public class RemovePromotionCommandHandler : IRequestHandler<RemovePromotionCommandRequest, RemovePromotionCommandResponse>
    {
        readonly IPromotionReadRepository _readRepository;
        readonly IPromotionWriteRepository _writeRepository;

        public RemovePromotionCommandHandler(IPromotionReadRepository readRepository, IPromotionWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<RemovePromotionCommandResponse> Handle(RemovePromotionCommandRequest request, CancellationToken cancellationToken)
        {
            Promotion promotion = await _readRepository.GetWhereAsync(p => p.ID.ToString() == request.Id, true);
            _writeRepository.RemovePermanently(promotion);
            await _writeRepository.SaveAsync();
            return new RemovePromotionCommandResponse
            {
                Message = "Kampaniya uğurla silindi"
            };
        }
    }
}
