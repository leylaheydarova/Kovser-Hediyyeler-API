using FluentValidation;
using KovserHedieyyeler.Application.DTOs.Department;
using KovserHedieyyeler.Application.DTOs.SocialMedias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Validation.Departments
{
    public class DepartmentCommandDtoValidation:AbstractValidator<DepartmentCommandDto>
    {
        public DepartmentCommandDtoValidation()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty();
            RuleFor(x=>x.Phone)
                .NotEmpty()
                .NotNull();
        }
    }
}
