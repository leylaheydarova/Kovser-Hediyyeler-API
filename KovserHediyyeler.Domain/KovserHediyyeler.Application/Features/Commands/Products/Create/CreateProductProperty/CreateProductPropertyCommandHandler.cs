using KovserHediyyeler.Application.Repositories.Products;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Create.CreateProductProperty
{
    public class CreateProductPropertyCommandHandler : IRequestHandler<CreateProductPropertyCommandRequest, CreateProductPropertyCommandResponse>
    {
        readonly IProductPropertyWriteRepository _repository;

        public CreateProductPropertyCommandHandler(IProductPropertyWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateProductPropertyCommandResponse> Handle(CreateProductPropertyCommandRequest request, CancellationToken cancellationToken)
        {
            ProductProperty property = new ProductProperty
            {
                ID = Guid.NewGuid(),
                Name = request.Dto.Name,
                Value = request.Dto.Value,
                ProductID = Guid.Parse(request.ProductId)
            };
            await _repository.AddAsync(property);
            await _repository.SaveAsync();

            return new CreateProductPropertyCommandResponse
            {
                StatusCode = 201,
                Message = "Məhsul xüsusiyyəti uğurla əlavə edildi!"
            };
        }
    }
}
