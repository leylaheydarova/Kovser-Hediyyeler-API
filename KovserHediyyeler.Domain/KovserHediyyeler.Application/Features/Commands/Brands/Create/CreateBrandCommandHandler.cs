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
        readonly IHttpContextAccessor _accessor;
        readonly IWebHostEnvironment _env;

        public CreateBrandCommandHandler(IBrandWriteRepository repository, IHttpContextAccessor accessor, IWebHostEnvironment env)
        {
            _repository = repository;
            _accessor = accessor;
            _env = env;
        }

        public async Task<CreateBrandCommandResponse> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Dto == null) throw new BadRequestException();
            Brand brand = new Brand
            {
                ID = Guid.NewGuid(),
                Name = request.Dto.Name,
                Image = request.Dto.file.UploadFile(_env.WebRootPath, FilePaths.BrandImagePath),
                ImageURL = $"{_accessor.HttpContext.Request.Scheme}://{_accessor.HttpContext.Request.Host}/{request.Dto.file.FileName}"
            };

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
