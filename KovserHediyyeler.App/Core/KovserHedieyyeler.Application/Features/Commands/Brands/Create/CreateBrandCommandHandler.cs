using AutoMapper;
using KovserHedieyyeler.Application.Exceptions.BadRequestExceptions;
using KovserHedieyyeler.Application.Repositories.Abstractions.Brands;
using KovserHediyyeler.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace KovserHedieyyeler.Application.Features.Commands.Brands.Create
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommandRequest, CreateBrandCommandResponse>
    {
        readonly IBrandWriteRepository _repository;
        readonly IMapper _mapper;
        readonly IHttpContextAccessor _accessor;

        public CreateBrandCommandHandler(IBrandWriteRepository repository, IMapper mapper, IHttpContextAccessor accessor)
        {
            _repository = repository;
            _mapper = mapper;
            _accessor = accessor;
        }

        public async Task<CreateBrandCommandResponse> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            if(request.Dto == null) throw new BadRequestException();
            Brand brand = _mapper.Map<Brand>(request.Dto);
            brand.ImageURL = _accessor.HttpContext.Request.Scheme + "//" + _accessor.HttpContext.Request.Host + $"/{brand.Image}";
            if(brand == null) throw new BadRequestException();
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
