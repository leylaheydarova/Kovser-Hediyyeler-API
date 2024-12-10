using FluentValidation;
using KovserHediyyeler.Application.DTOs.Baskets;

namespace KovserHediyyeler.Application.Validations.Baskets
{
    public class BasketCommandDtoValidation : AbstractValidator<BasketCommandDto>
    {
        public BasketCommandDtoValidation()
        {
            RuleFor(b => b.Count)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);
            RuleFor(b => b.ProductId)
                .NotEmpty()
                .NotNull();
        }
    }
}
