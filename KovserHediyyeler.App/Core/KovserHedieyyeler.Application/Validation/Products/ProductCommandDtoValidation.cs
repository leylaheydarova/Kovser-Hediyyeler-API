using FluentValidation;
using KovserHedieyyeler.Application.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Validation.Products
{
    public class ProductCommandDtoValidation:AbstractValidator<ProductCommandDto>
    {
        public ProductCommandDtoValidation()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty();
            RuleFor(x=>x.Stock)
                .NotEmpty()
                .NotNull()
                .GreaterThanOrEqualTo(0);
            RuleFor(x => x.Price)
                .NotEmpty()
                .NotNull()
                .GreaterThanOrEqualTo(0);

        }
    }
}
