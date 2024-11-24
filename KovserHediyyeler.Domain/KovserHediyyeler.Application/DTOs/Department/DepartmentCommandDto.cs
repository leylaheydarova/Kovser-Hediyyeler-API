using KovserHedieyyeler.Application.DTOs.SocialMedias;
using KovserHedieyyeler.Application.Validation.Files;
using Microsoft.AspNetCore.Http;

namespace KovserHedieyyeler.Application.DTOs.Department
{
    public class DepartmentCommandDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        [MaxFileSize(3)]
        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        public IFormFile File { get; set; }
        public ICollection<SocialMediaCommandDto>? SocialMedias { get; set; }
    }
}
