
using KovserHedieyyeler.Application.DTOs.Addresses;
using KovserHedieyyeler.Application.Repositories.Abstractions.Addresses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KovserHedieyyeler.Application.Features.Queries.Employees.GetAll.GetAllEmployeeAddresses
{
    public class GetAllEmployeeAddressesQueryHandler : IRequestHandler<GetAllEmployeeAddressesQueryRequest, GetAllEmployeeAddressesQueryResponse>
    {
        readonly IAddressReadRepository _repository;

        public GetAllEmployeeAddressesQueryHandler(IAddressReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAllEmployeeAddressesQueryResponse> Handle(GetAllEmployeeAddressesQueryRequest request, CancellationToken cancellationToken)
        {
            var query = _repository.GetAllWhere(x => !x.isDeleted && x.EmployeID.ToString() == request.EmployeId, false);
            int totalCount = query.Count();
            List<AddressGetDto> dtos = new List<AddressGetDto>();
            dtos = await query.Skip(request.Page * request.Size)
                .Take(request.Size)
                .Select(x => new AddressGetDto
                {
                    Id = x.ID.ToString(),
                    City = x.City.ToString(),
                    Region = x.Region,
                    Street = x.Street,
                    Home = x.Home,
                    PostalCode = x.PostalCode,
                    IsCurrentAddress = x.IsCurrentAddress
                }).ToListAsync();

            return new GetAllEmployeeAddressesQueryResponse
            {
                Datas = dtos,
                TotalCount = totalCount
            };
        }

    }
}
