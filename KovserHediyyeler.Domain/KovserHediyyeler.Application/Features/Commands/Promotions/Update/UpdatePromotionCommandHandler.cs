using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Constants;
using KovserHediyyeler.Application.Extentions;
using KovserHediyyeler.Application.Repositories.Promotions;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Promotions.Update
{
    public class UpdatePromotionCommandHandler : IRequestHandler<UpdatePromotionCommandRequest, UpdatePromotionCommandResponse>
    {
        readonly IPromotionReadRepository _readRepository;
        readonly IPromotionWriteRepository _writeRepository;

        public UpdatePromotionCommandHandler(IPromotionReadRepository readRepository, IPromotionWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<UpdatePromotionCommandResponse> Handle(UpdatePromotionCommandRequest request, CancellationToken cancellationToken)
        {
            FileConstants constant = new FileConstants();
            Promotion promotion = await _readRepository.GetWhereAsync(p => p.ID.ToString() == request.Id && !p.isDeleted, true);
            if (promotion == null) throw new PromotionNotFoundException();
            var dto = request.Dto;
            promotion.Title = dto.Title != null ? dto.Title : promotion.Title;
            promotion.Description = dto.Description != null ? dto.Description : promotion.Description;
            promotion.Price = dto.Price != null ? dto.Price : promotion.Price;
            promotion.DiscountedPrice = dto.DiscountPersentage != null ? (dto.Price - ((dto.Price * (int)dto.DiscountPersentage) / 100)) : promotion.DiscountedPrice;
            promotion.ExpireDate = dto.ExpireDate != null ? (DateTime)dto.ExpireDate : promotion.ExpireDate;
            promotion.StartDate = dto.StartDate != null ? (DateTime)dto.StartDate : promotion.StartDate;
            promotion.ImageName = dto.Image != null ? dto.Image.UploadFile(constant.root, FilePaths.PromotionImagePath) : promotion.ImageName;
            promotion.ImageURL = dto.Image != null ? $"{constant.scheme}://{constant.host}/{dto.Image.FileName}" : promotion.ImageURL;

            _writeRepository.Update(promotion);
            await _writeRepository.SaveAsync();

            return new UpdatePromotionCommandResponse
            {
                Message = "Kampaniya uğurla yeniləndi"
            };
        }
    }
}
