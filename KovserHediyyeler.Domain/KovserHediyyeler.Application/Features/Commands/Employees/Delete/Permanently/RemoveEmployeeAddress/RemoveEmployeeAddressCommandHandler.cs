using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Addresses;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Employees.Delete.Permanently.RemoveEmployeeAddress
{
    public class RemoveEmployeeAddressCommandHandler : IRequestHandler<RemoveEmployeeAddressCommandRequest, RemoveEmployeeAddressCommandResponse>
    {
        readonly IAddressReadRepository _readRepository;
        readonly IAddressWriteRepository _writeRepository;

        public RemoveEmployeeAddressCommandHandler(IAddressReadRepository readRepository, IAddressWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<RemoveEmployeeAddressCommandResponse> Handle(RemoveEmployeeAddressCommandRequest request, CancellationToken cancellationToken)
        {
            Address address = await _readRepository.GetWhereAsync(x => x.ID.ToString() == request.Id, true);
            if (address == null) throw new NotFoundException("ünvan");
            _writeRepository.RemovePermanently(address);
            await _writeRepository.SaveAsync();

            return new RemoveEmployeeAddressCommandResponse
            {
                Message = "İşçi ünvanı uğurla silinmişdir"
            };
        }
    }
}

