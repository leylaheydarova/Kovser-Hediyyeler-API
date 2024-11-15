using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.SocialMedias;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Departments.Update.UpdateSocialMedia
{
    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommandRequest, UpdateSocialMediaCommandResponse>
    {
        readonly ISocialMediaReadRepository _readRepository;
        readonly ISocialMediaWriteRepository _writeRepository;

        public UpdateSocialMediaCommandHandler(ISocialMediaReadRepository readRepository, ISocialMediaWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<UpdateSocialMediaCommandResponse> Handle(UpdateSocialMediaCommandRequest request, CancellationToken cancellationToken)
        {
            SocialMedia socialMedia = await _readRepository.GetWhereAsync(x => !x.isDeleted && x.ID.ToString() == request.Id, true);
            if (socialMedia == null) throw new SocialMediaNotFoundException();
            var dto = request.Dto;
            socialMedia.NickName = dto.NickName != null ? dto.NickName : socialMedia.NickName;
            socialMedia.Name = dto.Name != null ? dto.Name : socialMedia.Name;
            socialMedia.URL = dto.URL != null ? dto.URL : socialMedia.URL;
            socialMedia.DepartmentID = dto.DepartmentID != null ? (Guid)dto.DepartmentID : socialMedia.DepartmentID;
            _writeRepository.Update(socialMedia);
            await _writeRepository.SaveAsync();
            return new UpdateSocialMediaCommandResponse()
            {
                Message = "Məlumat uğurla yeniləndi!"
            };
        }
    }
}
