using AutoMapper;
using AutoMapper.QueryableExtensions;
using KovserHedieyyeler.Application.DTOs.Employees;
using KovserHedieyyeler.Application.Repositories.Abstractions.Employees;
using KovserHediyyeler.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KovserHedieyyeler.Application.Features.Queries.Employees.GetAll
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQueryRequest, GetAllEmployeesQueryResponse>
    {
        readonly IEmployeeReadRepository _repository;
        readonly IMapper _mapper;

        public GetAllEmployeesQueryHandler(IEmployeeReadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetAllEmployeesQueryResponse> Handle(GetAllEmployeesQueryRequest request, CancellationToken cancellationToken)
        {
            var query = _repository.GetAllWhere(x => !x.isDeleted, false, nameof(Address));
            int totalCount = query.Count();
            List<EmployeeGetDto> dtos = new List<EmployeeGetDto>();
            dtos = await query.Skip(request.Page * request.Size)
                .Take(request.Size)
                .ProjectTo<EmployeeGetDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return new GetAllEmployeesQueryResponse
            {
                Dtos = dtos,
                TotalCount = totalCount
            };
        }
    }
}
