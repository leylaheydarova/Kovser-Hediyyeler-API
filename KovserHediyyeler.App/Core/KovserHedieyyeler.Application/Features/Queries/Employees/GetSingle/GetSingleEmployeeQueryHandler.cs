using AutoMapper;
using KovserHedieyyeler.Application.DTOs.Employees;
using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHedieyyeler.Application.Repositories.Abstractions.Employees;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Employees.GetSingle
{
    public class GetSingleEmployeeQueryHandler : IRequestHandler<GetSingleEmployeeQueryRequest, GetSingleEmployeeQueryResponse>
    {
        readonly IEmployeeReadRepository _repository;
        readonly IMapper _mapper;

        public GetSingleEmployeeQueryHandler(IEmployeeReadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetSingleEmployeeQueryResponse> Handle(GetSingleEmployeeQueryRequest request, CancellationToken cancellationToken)
        {
            Employee employee = await _repository.GetWhereAsync(x => !x.isDeleted && x.ID == Guid.Parse(request.Id), false, "Addresses");
            if(employee == null)
            {
                throw new EmployeeNotFoundException();
            }
            EmployeeGetDto dto = _mapper.Map<EmployeeGetDto>(employee);
            return new GetSingleEmployeeQueryResponse
            {
                Dto = dto
            };
        }
    }
}


