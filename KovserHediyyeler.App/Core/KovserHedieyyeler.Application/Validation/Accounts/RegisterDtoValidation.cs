using FluentValidation;
using KovserHedieyyeler.Application.DTOs.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Validation.Accounts
{
    public class RegisterDtoValidation:AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidation()
        {
            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.FirstName)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.LastName)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Phone)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.ConfirmPassword)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty();
        }
    }
}
