using FluentValidation;
using KovserHedieyyeler.Application.DTOs.Products.ProductProperty;

namespace KovserHedieyyeler.Application.Validation.Products
{
    public class ProductPropertyPostDtoValidation:AbstractValidator<ProductPropertyPostDto>
    {
        public ProductPropertyPostDtoValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Value)
                .NotEmpty()
                .NotNull();
        }
    }
}
