using KovserHedieyyeler.Application.DTOs.SocialMedias;
using KovserHedieyyeler.Application.Validation.Files;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace KovserHedieyyeler.Application.Features.Commands.Departments.Create
{
    public class CreateDepartmentCommandRequest:IRequest<CreateDepartmentCommandResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        [MaxFileSize(3)]
        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        public IFormFile file { get; set; }
        public string NickName { get; set; }
        public string LinkName { get; set; }
        public string URL { get; set; }
    }
}
