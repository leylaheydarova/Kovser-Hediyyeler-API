using AutoMapper;
using KovserHedieyyeler.Application.Exceptions;
using KovserHedieyyeler.Application.Repositories.Abstractions.Brands;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Brands.Create
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommandRequest, CreateBrandCommandResponse>
    {
        readonly IBrandWriteRepository _repository;
        readonly IMapper _mapper;

        public CreateBrandCommandHandler(IBrandWriteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<CreateBrandCommandResponse> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            Brand brand = _mapper.Map<Brand>(request.Dto);
            if(brand == null)
            {
                throw new BrandNotFoundException();
            }
            return Task.FromResult(new CreateBrandCommandResponse
            {
                StatusCode = 201,
                Message = "Brend uğurla əlavə edildi!"
            });
        }
    }
}
