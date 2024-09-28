using FluentValidation;
using KovserHedieyyeler.Application.DTOs.Positions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Validation.Positions
{
    public class PositionCommandDtoValidation:AbstractValidator<PositionCommandDto>
    {
        public PositionCommandDtoValidation()
        {
            RuleFor(x=>x.Status)
                .NotEmpty()
                .NotNull();

        }
    }
}
