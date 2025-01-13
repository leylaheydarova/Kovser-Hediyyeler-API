using FluentValidation;
using KovserHedieyyeler.Application.DTOs.Products.Products;

namespace KovserHediyyeler.Application.Validations.Products
{
    public class ProductPostDtoValidation : AbstractValidator<ProductPostDto>
    {
        public ProductPostDtoValidation()
        {
            RuleFor(p => p.Price)
                .NotNull()
                .NotEmpty()
                .GreaterThanOrEqualTo(0);
            RuleFor(p => p.Name)
                .NotNull()
                .NotEmpty();
            RuleFor(p => p.DepartmentID)
                .NotNull()
                .NotEmpty();
            RuleFor(p => p.CategoryID)
                .NotNull()
                .NotEmpty();

        }
    }
}
