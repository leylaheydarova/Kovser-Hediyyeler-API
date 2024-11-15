using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHedieyyeler.Application.Repositories.Abstractions.Products;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Update.UpdateProducts
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        readonly IProductReadRepository _readRepository;
        readonly IProductWriteRepository _writeRepository;

        public UpdateProductCommandHandler(IProductReadRepository readRepository, IProductWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product product = await _readRepository.GetWhereAsync(x => !x.isDeleted && x.ID.ToString() == request.Id, true);
            if (product == null) throw new ProductNotFoundException();
            var dto = request.Dto;
            var discountprice = dto.Price - dto.Price * (int)dto.DiscountPercentage / 100;
            product.Name = dto.Name != null ? dto.Name : product.Name;
            product.Description = dto.Description != null ? dto.Description : product.Description;
            product.Stock = dto.Stock != null ? dto.Stock : product.Stock;
            product.Price = dto.Price != null ? dto.Price : product.Price;
            product.DiscountedPrice = dto.DiscountPercentage == null ? product.DiscountedPrice : discountprice;
            product.isSingleColour = dto.isSingleColour != null ? dto.isSingleColour : product.isSingleColour;
            product.BrandID = dto.BrandID != null ? dto.BrandID : product.BrandID;
            product.DepartmentID = dto.DepartmentID != null ? (Guid)dto.DepartmentID : product.DepartmentID;
            product.CategoryID = dto.CategoryID != null ? (Guid)dto.CategoryID : product.CategoryID;

            _writeRepository.Update(product);
            await _writeRepository.SaveAsync();

            return new UpdateProductCommandResponse
            {
                Message = "Məhsul məlumatları uğurla yeniləndi"
            };
        }
    }
}
