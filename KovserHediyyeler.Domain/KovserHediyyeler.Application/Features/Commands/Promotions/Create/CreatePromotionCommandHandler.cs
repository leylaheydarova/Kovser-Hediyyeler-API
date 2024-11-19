using KovserHediyyeler.Application.Constants;
using KovserHediyyeler.Application.Extentions;
using KovserHediyyeler.Application.Repositories.Promotions;
using KovserHediyyeler.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace KovserHediyyeler.Application.Features.Commands.Promotions.Create
{
    public class CreatePromotionCommandHandler : IRequestHandler<CreatePromotionCommandRequest, CreatePromotionCommandResponse>
    {
        readonly IPromotionWriteRepository _writeRepository;
        readonly FileConstants _fileConstants;

        public CreatePromotionCommandHandler(IPromotionWriteRepository writeRepository,
                                             IHttpContextAccessor httpContextAccessor,
                                             IWebHostEnvironment webHostEnvironment)
        {
            _writeRepository = writeRepository;
            _fileConstants = new FileConstants(httpContextAccessor, webHostEnvironment);
        }

        public async Task<CreatePromotionCommandResponse> Handle(CreatePromotionCommandRequest request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;
            Promotion promotion = new Promotion
            {
                ID = Guid.NewGuid(),
                Title = dto.Title,
                Description = dto.Description,
                Price = dto.Price,
                DiscountedPrice = (dto.Price - ((dto.Price * (int)dto.DiscountPersentage) / 100)),
                ImageName = dto.Image.UploadFile(_fileConstants.root, FilePaths.PromotionImagePath),
                ImageURL = $"{_fileConstants.scheme}://{_fileConstants.host}/{dto.Image.FileName}",
                ExpireDate = dto.ExpireDate,
                StartDate = dto.StartDate
            };
            await _writeRepository.AddAsync(promotion);
            await _writeRepository.SaveAsync();

            return new CreatePromotionCommandResponse
            {
                StatusCode = 201,
                Message = "Kampaniya uğurla yaradıldı"
            };
        }
    }
}
