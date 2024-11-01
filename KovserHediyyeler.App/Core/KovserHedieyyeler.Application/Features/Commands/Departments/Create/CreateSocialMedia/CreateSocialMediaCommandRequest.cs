using KovserHedieyyeler.Application.DTOs.SocialMedias;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Departments.Create.CreateSocialMedia
{
    public class CreateSocialMediaCommandRequest:CreateCommandRequest<SocialMediaCommandDto>, IRequest<CreateSocialMediaCommandResponse>
    {
        public string DepartmentId { get; set; }
    }
}
