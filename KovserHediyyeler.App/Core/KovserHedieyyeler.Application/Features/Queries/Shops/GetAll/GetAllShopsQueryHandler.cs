using KovserHedieyyeler.Application.DTOs.Shops;
using KovserHedieyyeler.Application.Repositories.Abstractions.Shops;
using KovserHediyyeler.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Features.Queries.Shops.GetAll
{
    public class GetAllShopsQueryHandler : IRequestHandler<GetAllShopsQueryRequest, GetAllShopsQueryResponse>
    {
        readonly IShopReadRepository _repository;

        public GetAllShopsQueryHandler(IShopReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAllShopsQueryResponse> Handle(GetAllShopsQueryRequest request, CancellationToken cancellationToken)
        {
            var query = _repository.GetAllWhere(x => !x.isDeleted, false);
            int totalCount = query.Count();
            List<ShopGetAllDto> dtos = new List<ShopGetAllDto>();
            dtos = await query.Skip(request.Page * request.Size)
                .Take(request.Size)
                .Select(x => new ShopGetAllDto
                {
                    Id = x.ID.ToString(),
                    Name = x.Name,
                    Description = x.Description,
                    Phone = x.Phone
                }).ToListAsync();
            return new GetAllShopsQueryResponse
            {
                Dtos = dtos,
                TotalCount = totalCount
            };
        }
    }
}
