
using KovserHedieyyeler.Application.Repositories.Abstractions.SocialMedias;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Departments.Create.CreateSocialMedia
{
    public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommandRequest, CreateSocialMediaCommandResponse>
    {
        readonly ISocialMediaWriteRepository _repository;

        public CreateSocialMediaCommandHandler(ISocialMediaWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateSocialMediaCommandResponse> Handle(CreateSocialMediaCommandRequest request, CancellationToken cancellationToken)
        {
            var socialMedia = new SocialMedia
            {
                ID = Guid.NewGuid(),
                Name = request.Dto.Name,
                NickName = request.Dto.NickName,
                URL = request.Dto.URL,
                DepartmentID = Guid.Parse(request.DepartmentId)
            };
            await _repository.AddAsync(socialMedia);
            await _repository.SaveAsync();
            return new CreateSocialMediaCommandResponse
            {
                StatusCode = 201,
                Message = "Sosyal Media uğurla əlavə edildi!"
            };
        }
    }
}
