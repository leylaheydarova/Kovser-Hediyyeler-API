using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Products;
using KovserHediyyeler.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Update.UpdateProductImages
{
    public class UpdateProductImageCommandHandler : IRequestHandler<UpdateProductImageCommandRequest, UpdateProductImageCommandResponse>
    {
        readonly IProductImageFileReadRepository _readRepository;
        readonly IProductImageFileWriteRepository _writeRepository;
        readonly IHttpContextAccessor _accessor;

        public UpdateProductImageCommandHandler(IProductImageFileReadRepository readRepository, IProductImageFileWriteRepository writeRepository, IHttpContextAccessor accessor)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _accessor = accessor;
        }

        public async Task<UpdateProductImageCommandResponse> Handle(UpdateProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            ProductImageFile image = await _readRepository.GetWhereAsync(x => !x.isDeleted && x.ID.ToString() == request.Id, true);
            if (image == null) throw new ProductImageNotFoundException();
            image.FileName = request.Dto.file != null ? request.Dto.file.FileName : image.FileName;
            image.Path = request.Dto.file != null
                ? $"{_accessor.HttpContext.Request.Scheme}://{_accessor.HttpContext.Request.Host}/{request.Dto.file.FileName}"
                : image.Path;
            image.IsMain = request.Dto.IsMain != null ? request.Dto.IsMain : image.IsMain;

            _writeRepository.Update(image);
            await _writeRepository.SaveAsync();

            return new UpdateProductImageCommandResponse
            {
                Message = "Məhsul şəkli uğurla yeniləndi!"
            };
        }
    }
}
