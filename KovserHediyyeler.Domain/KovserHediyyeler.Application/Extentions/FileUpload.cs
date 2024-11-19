using Microsoft.AspNetCore.Http;

namespace KovserHediyyeler.Application.Extentions
{
    public static class FileUpload
    {
        public static string UploadFile(this IFormFile file, string root, string path)
        {
            string filename = Guid.NewGuid().ToString() + file.FileName;
            string fullpath = Path.Combine(root, path, filename);

            using (FileStream stream = new FileStream(fullpath, FileMode.Create))
            {
                file.CopyToAsync(stream);
            }
            return filename;
        }
    }
}
