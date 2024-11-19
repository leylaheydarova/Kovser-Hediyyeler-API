using KovserHedieyyeler.Application.Exceptions.BadRequestExceptions;
using KovserHediyyeler.Application.Constants;
using KovserHediyyeler.Application.Extentions;
using KovserHediyyeler.Application.Repositories.Brands;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Brands.Create
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommandRequest, CreateBrandCommandResponse>
    {
        readonly IBrandWriteRepository _repository;

        public CreateBrandCommandHandler(IBrandWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateBrandCommandResponse> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            FileConstants constant = new FileConstants();
            if (request.Dto == null) throw new BadRequestException();
            Brand brand = new Brand
            {
                ID = Guid.NewGuid(),
                Name = request.Dto.Name,
                Image = request.Dto.file.UploadFile(constant.root, FilePaths.BrandImagePath),
                ImageURL = $"{constant.scheme}://{constant.host}/{request.Dto.file.FileName}"
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
