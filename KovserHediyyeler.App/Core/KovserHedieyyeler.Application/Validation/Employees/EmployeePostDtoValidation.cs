using FluentValidation;
using KovserHedieyyeler.Application.DTOs.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Validation.Employees
{
    public class EmployeePostDtoValidation:AbstractValidator<EmployeePostDto>
    {
        public EmployeePostDtoValidation()
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
            RuleFor(x=>x.isRemote) 
                .NotEmpty()
                .NotNull();
        }
    }
}
