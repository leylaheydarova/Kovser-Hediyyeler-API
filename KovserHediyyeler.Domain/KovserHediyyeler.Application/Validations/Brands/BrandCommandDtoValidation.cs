using FluentValidation;
using KovserHedieyyeler.Application.DTOs.Brands;

namespace KovserHediyyeler.Application.Validations.Brands
{
    public class BrandCommandDtoValidation : AbstractValidator<BrandCommandDto>
    {
        public BrandCommandDtoValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull();
        }
    }
}
