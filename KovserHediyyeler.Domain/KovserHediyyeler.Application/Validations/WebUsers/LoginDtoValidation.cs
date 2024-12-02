using FluentValidation;
using KovserHediyyeler.Application.DTOs.WebUsers;

namespace KovserHediyyeler.Application.Validations.WebUsers
{
    public class LoginDtoValidation : AbstractValidator<LoginDto>
    {
        public LoginDtoValidation()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .MinimumLength(8);
        }
    }
}
