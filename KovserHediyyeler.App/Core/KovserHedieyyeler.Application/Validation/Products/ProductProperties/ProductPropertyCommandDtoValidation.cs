using FluentValidation;
using KovserHedieyyeler.Application.DTOs.Products.ProductProperty;

namespace KovserHedieyyeler.Application.Validation.Products.ProductProperties
{
    public class ProductPropertyCommandDtoValidation : AbstractValidator<ProductPropertyCommandDto>
    {
        public ProductPropertyCommandDtoValidation()
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
