using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.WebUsers.GetAll.GetAllUserAddresses
{
    public class GetAlluserAddressesQueryHandler : IRequestHandler<GetAllUserAddressesQueryRequest, GetAllUserAddressesQueryResponse>
    {
        readonly IUserService _service;

        public GetAlluserAddressesQueryHandler(IUserService service)
        {
            _service = service;
        }

        public async Task<GetAllUserAddressesQueryResponse> Handle(GetAllUserAddressesQueryRequest request, CancellationToken cancellationToken)
        {
            var dtos = await _service.GetAllUserAddresses(request.Page, request.Size, request.UserIdOrEmail);
            return new GetAllUserAddressesQueryResponse
            {
                Datas = dtos,
                TotalCount = dtos.Count
            };
        }
    }
}
