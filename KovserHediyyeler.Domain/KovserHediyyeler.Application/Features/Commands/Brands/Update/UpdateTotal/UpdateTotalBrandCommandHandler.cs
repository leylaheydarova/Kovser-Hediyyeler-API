using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Constants;
using KovserHediyyeler.Application.Extentions;
using KovserHediyyeler.Application.Repositories.Brands;
using KovserHediyyeler.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;


namespace KovserHedieyyeler.Application.Features.Commands.Brands.Update.UpdateAll
{
    public class UpdateTotalBrandCommandHandler : IRequestHandler<UpdateTotalBrandCommandRequest, UpdateTotalBrandCommandResponse>
    {
        readonly IBrandReadRepository _readRepository;
        readonly IBrandWriteRepository _writeRepository;
        readonly IHttpContextAccessor _accessor;
        readonly IWebHostEnvironment _env;

        public UpdateTotalBrandCommandHandler(IBrandReadRepository readRepository, IBrandWriteRepository writeRepository, IHttpContextAccessor accessor, IWebHostEnvironment env)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _accessor = accessor;
            _env = env;
        }

        public async Task<UpdateTotalBrandCommandResponse> Handle(UpdateTotalBrandCommandRequest request, CancellationToken cancellationToken)
        {
            var id = request.Id.ToString();
            Brand brand = await _readRepository.GetWhereAsync(x => !x.isDeleted && x.ID.ToString() == request.Id, true);
            if (brand == null) throw new BrandNotFoundException();
            brand.Name = request.Dto.Name;
            brand.Image = request.Dto.file.UploadFile(_env.WebRootPath, FilePaths.BrandImagePath);
            brand.ImageURL = _accessor.HttpContext.Request.Scheme + "://" + _accessor.HttpContext.Request.Host + $"/{brand.Image}";

            _writeRepository.Update(brand);
            await _writeRepository.SaveAsync();
            return new UpdateTotalBrandCommandResponse
            {
                Message = "Brend məlumatları uğurla yeniləndi!"
            };
        }
    }
}
