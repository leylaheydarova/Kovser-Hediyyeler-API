using AutoMapper;
using KovserHedieyyeler.Application.Exceptions.BadRequestExceptions;
using KovserHedieyyeler.Application.Repositories.Abstractions.Categories;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Categories.Create
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
    {
        readonly ICategoryWriteRepository _repository;
        readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryWriteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category category = _mapper.Map<Category>(request.Dto);
            if (category == null) throw new BadRequestException();
            _repository.AddAsync(category);
            await _repository.SaveAsync();

            return new CreateCategoryCommandResponse
            {
                StatusCode = 201,
                Message = "Kateqoriya uğurla əlavə olundu!"
            };
        }
    }
}
