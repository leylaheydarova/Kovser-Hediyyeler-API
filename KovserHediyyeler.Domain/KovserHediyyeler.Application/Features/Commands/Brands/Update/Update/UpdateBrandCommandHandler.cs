using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Constants;
using KovserHediyyeler.Application.Extentions;
using KovserHediyyeler.Application.Repositories.Brands;
using KovserHediyyeler.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace KovserHedieyyeler.Application.Features.Commands.Brands.Update.Update
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommandRequest, UpdateBrandCommandResponse>
    {
        readonly IBrandReadRepository _readRepository;
        readonly IBrandWriteRepository _writeRepository;
        readonly IWebHostEnvironment _env;
        readonly IHttpContextAccessor _accessor;
        public UpdateBrandCommandHandler(IBrandReadRepository readRepository, IBrandWriteRepository writeRepository, IWebHostEnvironment env, IHttpContextAccessor accessor)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _env = env;
            _accessor = accessor;
        }

        public async Task<UpdateBrandCommandResponse> Handle(UpdateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            var scheme = _accessor.HttpContext.Request.Scheme;
            var host = _accessor.HttpContext.Request.Host;
            Brand brand = await _readRepository.GetWhereAsync(x => !x.isDeleted && x.ID.ToString() == request.Id, true);
            if (brand == null) throw new BrandNotFoundException();
            brand.Name = request.Dto.Name != null ? request.Dto.Name : brand.Name;
            brand.Image = request.Dto.file != null
                ? request.Dto.file.UploadFile(_env.WebRootPath, FilePaths.BrandImagePath)
                : brand.Image;
            brand.ImageURL = request.Dto.file != null
                ? $"{scheme}://{host}/{FilePaths.BrandImagePath}/{brand.Image}"
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
