using FluentValidation;
using KovserHediyyeler.Service.Dtos.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Service.Validations.Departments
{
    public class DepartmentPostDtoValidation:AbstractValidator<DepartmentPostDto>
    {
        public DepartmentPostDtoValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(30);
            RuleFor(x => x.Description)
                .MaximumLength(300);
            
        }
    }
}
