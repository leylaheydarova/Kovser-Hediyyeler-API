using KovserHedieyyeler.Application.DTOs.SocialMedias;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Departments.Update.UpdateSocialMedia
{
    public class UpdateSocialMediaCommandRequest : UpdateCommandRequest<SocialMediaUpdateDto>, IRequest<UpdateSocialMediaCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
