using System.Linq;
using AutoMapper;
using KovserHedieyyeler.Application.DTOs.Brands;
using KovserHedieyyeler.Application.Repositories.Abstractions.Brands;
using KovserHedieyyeler.Application.Repositories.Abstractions.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.EntityFrameworkCore;

namespace KovserHedieyyeler.Application.Features.Queries.Brands.GetAll
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
            int TotalCount = _repository.GetAllWhere(x=>!x.isDeleted,false).Count();
            var query = _repository.GetAllWhere(x => !x.isDeleted, false);
            List<BrandGetDto> dtos = new List<BrandGetDto>();
            dtos = await query
                .Skip(request.Page * request.Size)  
                .Take(request.Size)                
                .Select(x => new BrandGetDto
                {
                    Id = x.ID.ToString(), 
                    Name = x.Name,
                    Image = x.Image,
                }).ToListAsync();

            return new GetAllBrandsQueryResponse { Dtos = dtos };
        }
    }
}
