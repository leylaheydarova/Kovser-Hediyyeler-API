using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Addresses;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Employees.Delete.Permanently.RemoveEmployeeAddress
{
    public class RemoveAddressCommandHandler : IRequestHandler<RemoveAddressCommandRequest, RemoveAddressCommandResponse>
    {
        readonly IAddressReadRepository _readRepository;
        readonly IAddressWriteRepository _writeRepository;

        public RemoveAddressCommandHandler(IAddressReadRepository readRepository, IAddressWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<RemoveAddressCommandResponse> Handle(RemoveAddressCommandRequest request, CancellationToken cancellationToken)
        {
            Address address = await _readRepository.GetWhereAsync(x => x.ID.ToString() == request.Id, true);
            if (address == null) throw new NotFoundException("ünvan");
            _writeRepository.RemovePermanently(address);
            await _writeRepository.SaveAsync();
            return new RemoveAddressCommandResponse
            {
                Message = "İşçi ünvanı uğurla silinmişdir"
            };
        }
    }
}
