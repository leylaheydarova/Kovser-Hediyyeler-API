using KovserHedieyyeler.Application.Exceptions.BadRequestExceptions;
using KovserHediyyeler.Application.Constants;
using KovserHediyyeler.Application.Extentions;
using KovserHediyyeler.Application.Repositories.Brands;
using KovserHediyyeler.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace KovserHedieyyeler.Application.Features.Commands.Brands.Create
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommandRequest, CreateBrandCommandResponse>
    {
        readonly IBrandWriteRepository _repository;
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _accessor;
        public CreateBrandCommandHandler(IBrandWriteRepository repository, IWebHostEnvironment env, IHttpContextAccessor accessor)
        {
            _repository = repository;
            _env = env;
            _accessor = accessor;
        }

        public async Task<CreateBrandCommandResponse> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Dto == null) throw new BadRequestException();
            if (request.Dto.file is null)
                throw new BadRequestException();
            var scheme = _accessor.HttpContext.Request.Scheme;
            var host = _accessor.HttpContext.Request.Host;
            Brand brand = new Brand
            {
                ID = Guid.NewGuid(),
                Name = request.Dto.Name,
                Image = request.Dto.file.UploadFile(_env.WebRootPath, FilePaths.BrandImagePath),
                ImageURL = ""
            };
            brand.ImageURL = $"{scheme}://{host}/{FilePaths.BrandImagePath}/{brand.Image}";

            if (brand == null) throw new BadRequestException();
            await _repository.AddAsync(brand);
            await _repository.SaveAsync();

            return new CreateBrandCommandResponse
            {
                StatusCode = 201,
                Message = "Brend uğurla əlavə edildi!"
            };
        }
    }
}
