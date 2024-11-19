using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Constants;
using KovserHediyyeler.Application.Extentions;
using KovserHediyyeler.Application.Repositories.Brands;
using KovserHediyyeler.Domain.Models;
using MediatR;


namespace KovserHedieyyeler.Application.Features.Commands.Brands.Update.UpdateAll
{
    public class UpdateTotalBrandCommandHandler : IRequestHandler<UpdateTotalBrandCommandRequest, UpdateTotalBrandCommandResponse>
    {
        readonly IBrandReadRepository _readRepository;
        readonly IBrandWriteRepository _writeRepository;

        public UpdateTotalBrandCommandHandler(IBrandReadRepository readRepository, IBrandWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<UpdateTotalBrandCommandResponse> Handle(UpdateTotalBrandCommandRequest request, CancellationToken cancellationToken)
        {
            FileConstants constant = new FileConstants();
            var id = request.Id.ToString();
            Brand brand = await _readRepository.GetWhereAsync(x => !x.isDeleted && x.ID.ToString() == request.Id, true);
            if (brand == null) throw new BrandNotFoundException();
            brand.Name = request.Dto.Name;
            brand.Image = request.Dto.file.UploadFile(constant.root, FilePaths.BrandImagePath);
            brand.ImageURL = $"{constant.scheme}://{constant.host}/{brand.Image}";

            _writeRepository.Update(brand);
            await _writeRepository.SaveAsync();
            return new UpdateTotalBrandCommandResponse
            {
                Message = "Brend məlumatları uğurla yeniləndi!"
            };
        }
    }
}
