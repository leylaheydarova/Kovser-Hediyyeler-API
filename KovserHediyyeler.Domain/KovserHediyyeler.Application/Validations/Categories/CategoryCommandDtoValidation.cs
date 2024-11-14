using FluentValidation;
using KovserHedieyyeler.Application.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Validation.Categories
{
    public class CategoryCommandDtoValidation:AbstractValidator<CategoryCommandDto>
    {
        public CategoryCommandDtoValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull();
        }
    }
}
