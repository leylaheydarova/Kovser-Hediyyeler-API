

using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.SocialMedias;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Departments.Delete.Permanently.RemoveSocialMedia
{
    public class RemoveSocialMediaCommandHandler : IRequestHandler<RemoveSocialMediaCommandRequest, RemoveSocialMediaCommandResponse>
    {
        readonly ISocialMediaReadRepository _readRepository;
        readonly ISocialMediaWriteRepository _writeRepository;

        public RemoveSocialMediaCommandHandler(ISocialMediaReadRepository readRepository, ISocialMediaWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<RemoveSocialMediaCommandResponse> Handle(RemoveSocialMediaCommandRequest request, CancellationToken cancellationToken)
        {
            SocialMedia socialMedia = await _readRepository.GetWhereAsync(x => x.ID.ToString() == request.Id, true);
            if (socialMedia == null) throw new SocialMediaNotFoundException();
            _writeRepository.RemovePermanently(socialMedia);
            await _writeRepository.SaveAsync();

            return new RemoveSocialMediaCommandResponse
            {
                Message = "Sosyal Media məlumatları uğurla silinmişdir!"
            };
        }
    }
}
