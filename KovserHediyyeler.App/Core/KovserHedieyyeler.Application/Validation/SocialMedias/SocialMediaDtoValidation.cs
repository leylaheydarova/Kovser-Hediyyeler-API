using FluentValidation;
using KovserHedieyyeler.Application.DTOs.SocialMedias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Validation.SocialMedias
{
    public class SocialMediaDtoValidation:AbstractValidator<SocialMediaDto>
    {
        public SocialMediaDtoValidation()
        {
            RuleFor(x => x.NickName)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty();
            RuleFor(x=>x.URL)
                .NotEmpty()
                .NotNull();
        }
    }
}
