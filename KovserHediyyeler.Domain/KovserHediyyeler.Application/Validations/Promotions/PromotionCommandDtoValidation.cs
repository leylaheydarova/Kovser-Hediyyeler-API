using FluentValidation;
using KovserHedieyyeler.Application.DTOs.Promotion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Validation.Promotions
{
    public class PromotionCommandDtoValidation:AbstractValidator<PromotionCommandDto>
    {
        public PromotionCommandDtoValidation()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull();
            RuleFor(x=>x.ExpireDate)
                .NotEmpty()
                .NotNull();
        }
    }
}
