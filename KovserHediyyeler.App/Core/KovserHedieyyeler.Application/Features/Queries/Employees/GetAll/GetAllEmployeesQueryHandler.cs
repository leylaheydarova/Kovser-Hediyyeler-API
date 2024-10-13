using AutoMapper;
using AutoMapper.QueryableExtensions;
using KovserHedieyyeler.Application.DTOs.Addresses;
using KovserHedieyyeler.Application.DTOs.Employees;
using KovserHedieyyeler.Application.Repositories.Abstractions.Employees;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var query = _repository.GetAllWhere(x => !x.isDeleted, false).Include(x=>x.Address);
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
