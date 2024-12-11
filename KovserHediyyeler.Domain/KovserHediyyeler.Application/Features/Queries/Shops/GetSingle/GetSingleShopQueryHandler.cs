using KovserHedieyyeler.Application.DTOs.Addresses;
using KovserHedieyyeler.Application.DTOs.Shops;
using KovserHediyyeler.Application.DTOs.Employees;
using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Shops;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Shops.GetSingle
{
    public class GetSingleShopQueryHandler : IRequestHandler<GetSingleShopQueryRequest, GetSingleShopQueryResponse>
    {
        readonly IShopReadRepository _repository;

        public GetSingleShopQueryHandler(IShopReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetSingleShopQueryResponse> Handle(GetSingleShopQueryRequest request, CancellationToken cancellationToken)
        {
            Shop shop = await _repository.GetWhereAsync(x => !x.isDeleted && x.ID == Guid.Parse(request.Id), false, "Employees.Position", "Addresses"); //add Products to include 

            if (shop == null) throw new NotFoundException("mağaza");

            var address = shop.Addresses.FirstOrDefault(a => a.IsCurrentAddress && !a.isDeleted);


            ShopGetSingleDto dto = new ShopGetSingleDto
            {
                Id = shop.ID.ToString(),
                Name = shop.Name,
                Phone = shop.Phone,
                Description = shop.Description,
                Address = new AddressGetDto
                {
                    Id = address.ID.ToString(),
                    City = address.City.ToString(),
                    Region = address.Region,
                    District = address.District,
                    Street = address.Street,
                    Home = address.Home,
                    PostalCode = address.PostalCode,
                    IsCurrentAddress = address.IsCurrentAddress
                },
                Employees = shop.Employees.Select(e => new EmployeeGetAllDto
                {
                    Id = e.ID.ToString(),
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    PositionName = e.Position.Status
                }).ToList()
            };

            return new GetSingleShopQueryResponse
            {
                Dto = dto
            };
        }
    }
}
