using FluentValidation;
using KovserHedieyyeler.Application.DTOs.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Validation.Addresses
{
    public class AddressCommandDtoValidation:AbstractValidator<AddressCommandDto>
    {
        public AddressCommandDtoValidation()
        {
            RuleFor(x => x.Region)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.City)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Street)
                .NotEmpty()
                .NotNull();
        }
    }
}
