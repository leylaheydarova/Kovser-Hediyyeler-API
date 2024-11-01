using FluentValidation;
using KovserHedieyyeler.Application.DTOs.SocialMedias;


namespace KovserHedieyyeler.Application.Validation.SocialMedias
{
    public class SocialMediaCommandDtoValidation:AbstractValidator<SocialMediaCommandDto>
    {
        public SocialMediaCommandDtoValidation()
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
