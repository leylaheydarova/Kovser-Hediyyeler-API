using FluentValidation;
using KovserHediyyeler.Service.Dtos.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Service.Validations.Categories
{
    public class CategoryPutDtoValidation:AbstractValidator<CategoryPutDto>
    {
        public CategoryPutDtoValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(30);
        }
    }
}
