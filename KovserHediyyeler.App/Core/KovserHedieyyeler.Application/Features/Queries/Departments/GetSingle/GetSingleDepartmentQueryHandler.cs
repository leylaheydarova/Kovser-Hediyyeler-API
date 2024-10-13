using AutoMapper;
using KovserHedieyyeler.Application.DTOs.Department;
using KovserHedieyyeler.Application.Exceptions;
using KovserHedieyyeler.Application.Repositories.Abstractions.Departments;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Departments.GetSingle
{
    public class GetSingleDepartmentQueryHandler : IRequestHandler<GetSingleDepartmentQueryRequest, GetSingleDepartmentQueryResponse>
    {
        readonly IDepartmentReadRepository _repository;
        readonly IMapper _mapper;

        public GetSingleDepartmentQueryHandler(IDepartmentReadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetSingleDepartmentQueryResponse> Handle(GetSingleDepartmentQueryRequest request, CancellationToken cancellationToken)
        {
            Department department = await _repository.GetWhereAsync(x => !x.isDeleted && x.ID == Guid.Parse(request.Id), false, nameof(SocialMedia));
            if(department == null)
            {
                throw new DepartmentNotFoundException();
            }
            DepartmentGetSingleDto dto = _mapper.Map<DepartmentGetSingleDto>(department);
            return new GetSingleDepartmentQueryResponse
            {
                Dto = dto
            };
        }
    }
}
