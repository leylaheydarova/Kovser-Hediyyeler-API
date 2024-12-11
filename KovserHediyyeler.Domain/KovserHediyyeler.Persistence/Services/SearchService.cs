using KovserHedieyyeler.Application.DTOs.Products.ProductImage;
using KovserHedieyyeler.Application.DTOs.Products.Products;
using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Constants;
using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Products;
using Microsoft.EntityFrameworkCore;

namespace KovserHediyyeler.Persistence.Services
{
    public class SearchService : ISearchService
    {
        readonly IProductReadRepository _repository;

        public SearchService(IProductReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductGetAllDto>> SearchProducts(string query)
        {
            var products = _repository.GetAllWhere(p => p.Name.Contains(query) || p.Description.Contains(query), false, "Department", "Images");
            if (products == null) throw new NotFoundException("məhsul");
            var dtos = new List<ProductGetAllDto>();
            dtos = await products.Select(d => new ProductGetAllDto
            {
                Id = d.ID.ToString(),
                DepartmentName = d.Department.Name,
                Name = d.Name,
                Description = d.Description,
                Price = d.Price,
                DiscountedPrice = d.DiscountedPrice,
                Image = d.Images
                        .Where(image => image.IsMain)
                        .Select(image => new ProductImageGetDto
                        {
                            Id = image.ID.ToString(),
                            ImageName = image.FileName,
                            ImageURL = image.Path,
                            isMain = image.IsMain
                        }).FirstOrDefault() ?? new ProductImageGetDto
                        {
                            Id = Guid.NewGuid().ToString(),
                            ImageName = ConstantPaths.DefaultImage,
                            ImageURL = ConstantPaths.DefaultImageURL,
                            isMain = true
                        }
            }).ToListAsync();
            return dtos;
        }
    }
}
//todo:deqiqlesdir search kodunu