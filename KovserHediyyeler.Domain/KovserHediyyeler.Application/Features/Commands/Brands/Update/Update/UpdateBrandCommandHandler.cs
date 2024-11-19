using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Constants;
using KovserHediyyeler.Application.Extentions;
using KovserHediyyeler.Application.Repositories.Brands;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Brands.Update.Update
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommandRequest, UpdateBrandCommandResponse>
    {
        readonly IBrandReadRepository _readRepository;
        readonly IBrandWriteRepository _writeRepository;
        public UpdateBrandCommandHandler(IBrandReadRepository readRepository, IBrandWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<UpdateBrandCommandResponse> Handle(UpdateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            FileConstants constant = new FileConstants();
            Brand brand = await _readRepository.GetWhereAsync(x => !x.isDeleted && x.ID.ToString() == request.Id, true);
            if (brand == null) throw new BrandNotFoundException();
            brand.Name = request.Dto.Name != null ? request.Dto.Name : brand.Name;
            brand.Image = request.Dto.file != null
                ? request.Dto.file.UploadFile(constant.root, FilePaths.BrandImagePath)
                : brand.Image;
            brand.ImageURL = request.Dto.file != null
                ? $"{constant.scheme}://{constant.host}/{request.Dto.file.FileName}"
                : brand.ImageURL;
            _writeRepository.Update(brand);
            await _writeRepository.SaveAsync();
            return new UpdateBrandCommandResponse
            {
                Message = "Məlumat uğurla yeniləndi!"
            };
        }
    }
}
