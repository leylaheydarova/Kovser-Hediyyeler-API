using AutoMapper;
using KovserHedieyyeler.Application.Repositories.Abstractions.Employees;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Employees.Create
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommandRequest, CreateEmployeeCommandResponse>
    {
        readonly IEmployeeWriteRepository _repository;
        readonly IMapper _mapper;

        public CreateEmployeeCommandHandler(IEmployeeWriteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateEmployeeCommandResponse> Handle(CreateEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            Employee employee = _mapper.Map<Employee>(request);
            foreach (var addressDto in request.Dto.Addresses)
            {
                Address address = _mapper.Map<Address>(addressDto);
                employee.Address.Add(address);
            }
            await _repository.AddAsync(employee);
            await _repository.SaveAsync();
            return new CreateEmployeeCommandResponse
            {
                StatusCode = 201,
                Message = "İşçi uğurla əlavə edildi!"
            };
        }
    }
}
