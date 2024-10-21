using FluentValidation;
using KovserHedieyyeler.Application.DTOs.Employees;

namespace KovserHedieyyeler.Application.Validation.Employees
{
    public class EmployeePutDtoValidation:AbstractValidator<EmployeePutDto>
    {
        public EmployeePutDtoValidation()
        {
            RuleFor(x => x.FirstName)
                .NotNull()
                .NotNull();
            RuleFor(x => x.LastName)
                .NotNull()
                .NotNull();
            RuleFor(x => x.Phone)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.isRemote)
                .NotEmpty()
                .NotNull();
        }
    }
}
