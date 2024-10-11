using AutoMapper;
using KovserHedieyyeler.Application.DTOs.Brands;
using KovserHedieyyeler.Application.Repositories.Abstractions.Brands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Features.Queries.Brands.GetAllBrands
{
    public class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandsQueryRequest, GetAllBrandsQueryResponse>
    {
        private readonly IBrandReadRepository _repository;
        private readonly IMapper _mapper;

        public GetAllBrandsQueryHandler(IBrandReadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetAllBrandsQueryResponse> Handle(GetAllBrandsQueryRequest request, CancellationToken cancellationToken)
        {
            return new GetAllBrandsQueryResponse { Dtos = [] };
        }
    }
}
