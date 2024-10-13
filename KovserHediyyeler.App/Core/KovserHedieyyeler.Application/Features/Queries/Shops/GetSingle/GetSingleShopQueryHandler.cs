using AutoMapper;
using KovserHedieyyeler.Application.DTOs.Shops;
using KovserHedieyyeler.Application.Repositories.Abstractions.Shops;
using KovserHedieyyeler.Application.Repositories.Interfaces.Positions;
using KovserHediyyeler.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Features.Queries.Shops.GetSingle
{
    public class GetSingleShopQueryHandler : IRequestHandler<GetSingleShopQueryRequest, GetSingleShopQueryResponse>
    {
        readonly IShopReadRepository _repository;
        readonly IMapper _mapper;

        public GetSingleShopQueryHandler(IShopReadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetSingleShopQueryResponse> Handle(GetSingleShopQueryRequest request, CancellationToken cancellationToken)
        {
            Shop shop = await _repository.GetWhereAsync(x => !x.isDeleted && x.ID == Guid.Parse(request.Id), false, nameof(Employee), nameof(Product));
            ShopGetSingleDto dto = _mapper.Map<ShopGetSingleDto>(shop);
            return new GetSingleShopQueryResponse
            {
                Dto = dto
            };
        }
    }
}
