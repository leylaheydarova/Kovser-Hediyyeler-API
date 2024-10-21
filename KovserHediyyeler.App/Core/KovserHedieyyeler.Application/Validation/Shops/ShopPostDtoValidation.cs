using FluentValidation;
using KovserHedieyyeler.Application.DTOs.Shops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Validation.Shops
{
    public class ShopPostDtoValidation:AbstractValidator<ShopPostDto>
    {
        public ShopPostDtoValidation()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Phone)
                .NotNull()
                .NotEmpty();
        }
    }
}
