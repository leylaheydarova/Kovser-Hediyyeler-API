using FluentValidation;
using KovserHedieyyeler.Application.DTOs.Products.Products;

namespace KovserHedieyyeler.Application.Validation.Products.Products
{
    public class ProductPostDtoValidation : AbstractValidator<ProductPostDto>
    {
        public ProductPostDtoValidation()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Stock)
                .NotEmpty()
                .NotNull()
                .GreaterThanOrEqualTo(0);
            RuleFor(x => x.Price)
                .NotEmpty()
                .NotNull()
                .GreaterThanOrEqualTo(0);
        }
    }
}
