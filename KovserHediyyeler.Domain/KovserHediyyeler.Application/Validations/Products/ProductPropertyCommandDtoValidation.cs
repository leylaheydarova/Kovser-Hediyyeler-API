using FluentValidation;
using KovserHedieyyeler.Application.DTOs.Products.ProductProperty;

namespace KovserHediyyeler.Application.Validations.Products
{
    public class ProductPropertyCommandDtoValidation : AbstractValidator<ProductPropertyCommandDto>
    {
        public ProductPropertyCommandDtoValidation()
        {
            RuleFor(p => p.Name)
                .NotNull()
                .NotEmpty();
            RuleFor(p => p.Value)
                .NotNull()
                .NotEmpty();
        }
    }
}
