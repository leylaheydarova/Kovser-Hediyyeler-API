using KovserHedieyyeler.Application.DTOs.SocialMedias;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Features.Commands.Departments.Update.UpdateSocialMedia
{
    public class UpdateSocialMediaCommandRequest:UpdateCommandRequest<SocialMediaUpdateDto>, IRequest<UpdateSocialMediaCommandResponse>
    {
    }
}
