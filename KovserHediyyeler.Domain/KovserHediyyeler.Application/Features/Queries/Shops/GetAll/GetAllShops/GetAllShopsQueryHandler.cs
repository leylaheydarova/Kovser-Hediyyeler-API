using KovserHedieyyeler.Application.DTOs.Shops;
using KovserHediyyeler.Application.Repositories.Shops;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KovserHedieyyeler.Application.Features.Queries.Shops.GetAll.GetAllShops
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
            var query = _repository.GetAllWhere(x => !x.isDeleted, false, "Addresses");
            int totalCount = query.Count();
            List<ShopGetAllDto> dtos = new List<ShopGetAllDto>();
            dtos = await query.Skip(request.Page * request.Size)
                .Take(request.Size)
                .Select(x => new ShopGetAllDto
                {
                    Id = x.ID.ToString(),
                    Name = x.Name,
                    Description = x.Description,
                    Phone = x.Phone,
                    City = x.Addresses.FirstOrDefault(ad => ad.IsCurrentAddress && ad.ShopID == x.ID).GetCity
                }).ToListAsync();
            return new GetAllShopsQueryResponse
            {
                Datas = dtos,
                TotalCount = totalCount
            };
        }
    }
}
