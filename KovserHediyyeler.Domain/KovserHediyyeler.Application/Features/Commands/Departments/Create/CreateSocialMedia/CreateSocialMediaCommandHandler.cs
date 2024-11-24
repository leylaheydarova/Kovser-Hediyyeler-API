using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Departments.Create.CreateSocialMedia
{
    public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommandRequest, CreateSocialMediaCommandResponse>
    {
        readonly IDepartmentService _service;

        public CreateSocialMediaCommandHandler(IDepartmentService service)
        {
            _service = service;
        }

        public async Task<CreateSocialMediaCommandResponse> Handle(CreateSocialMediaCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.CreateDepartmentSocialMediaAsync(request.Dto, request.DepartmentId);

            return new CreateSocialMediaCommandResponse
            {
                StatusCode = 201,
                Message = "Sosyal Media uğurla əlavə edildi!"
            };
        }
    }
}
