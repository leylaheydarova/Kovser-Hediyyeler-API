using KovserHedieyyeler.Application.DTOs.Addresses;
using KovserHediyyeler.Application.Repositories.Addresses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KovserHedieyyeler.Application.Features.Queries.Shops.GetAll.GetAllShopAddresses
{
    public class GetAllShopAddressesQueryHandler : IRequestHandler<GetAllShopAddressesQueryRequest, GetAllShopAddressesQueryResponse>
    {
        readonly IAddressReadRepository _repository;

        public GetAllShopAddressesQueryHandler(IAddressReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAllShopAddressesQueryResponse> Handle(GetAllShopAddressesQueryRequest request, CancellationToken cancellationToken)
        {
            var query = _repository.GetAllWhere(x => !x.isDeleted && x.ShopID.ToString() == request.ShopId, false);
            int totalCount = query.Count();
            List<AddressGetDto> dtos = new List<AddressGetDto>();
            dtos = await query.Skip(request.Page * request.Size)
                .Take(request.Size)
                .Select(x => new AddressGetDto
                {
                    Id = x.ID.ToString(),
                    City = x.City.ToString(),
                    Region = x.Region,
                    District = x.District,
                    Street = x.Street,
                    Home = x.Home,
                    PostalCode = x.PostalCode,
                    IsCurrentAddress = x.IsCurrentAddress
                }).ToListAsync();

            return new GetAllShopAddressesQueryResponse
            {
                Datas = dtos,
                TotalCount = totalCount
            };
        }
    }
}
