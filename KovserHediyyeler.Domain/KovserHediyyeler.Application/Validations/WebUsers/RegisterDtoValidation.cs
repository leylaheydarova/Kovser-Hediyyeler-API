using FluentValidation;
using KovserHediyyeler.Application.DTOs.WebUsers;

namespace KovserHediyyeler.Application.Validations.WebUsers
{
    public class RegisterDtoValidation : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidation()
        {
            RuleFor(r => r.Email)
                .NotEmpty()
                .NotNull();
            RuleFor(r => r.FirstName)
                .NotEmpty()
                .NotNull();
            RuleFor(r => r.LastName)
                .NotEmpty()
                .NotNull();
            RuleFor(r => r.MiddleName)
                .NotEmpty()
                .NotNull();
            RuleFor(r => r.Phone)
                .NotEmpty()
                .NotNull();
        }
    }
}
