using AutoMapper;
using KovserHedieyyeler.Application.DTOs.Brands;
using KovserHedieyyeler.Application.Exceptions;
using KovserHedieyyeler.Application.Repositories.Abstractions.Brands;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Brands.GetSingle
{
    public class GetSingleBrandQueryHandler : IRequestHandler<GetSingleBrandQueryRequest, GetSingleBrandQueryResponse>
    {
        readonly IBrandReadRepository _repository;
        readonly IMapper _mapper;

        public GetSingleBrandQueryHandler(IBrandReadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetSingleBrandQueryResponse> Handle(GetSingleBrandQueryRequest request, CancellationToken cancellationToken)
        {
            Brand brand = await _repository.GetWhereAsync(x =>!x.isDeleted && x.ID.ToString() == request.Id, false);
            if (brand == null)
            {
                throw new BrandNotFoundException();
            }
            BrandGetDto dto = _mapper.Map<BrandGetDto>(brand);
            return new GetSingleBrandQueryResponse
            {
                Dto = dto
            };
        }
    }
}
