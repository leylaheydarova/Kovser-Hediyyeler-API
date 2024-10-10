using KovserHedieyyeler.Application.Abstractions.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Infrastructure.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _env;

        public FileService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<bool> CopyFileAsync(string path)
        {
            try
            {
                await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
                await fileStream.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
                //todo log!
            }
        }

        Task<string> RenameFileAsync(string fileName, string path)
        {
            string fileExtension = Path.GetExtension(fileName);
            string fileNameWithoutExtention = Path.GetFileNameWithoutExtension(fileName);

        }

        Task<string> SetFullPathforFileAsync(string fileName, string filePath)
        {
            throw new NotImplementedException();
        }

        public async Task<List<(string filename, string path)>> UploadFileAsync(string path, IFormFileCollection files)
        {
            string uploadPath = Path.Combine(path, _env.WebRootPath);
            if(!Directory.Exists(uploadPath)) {
                Directory.CreateDirectory(uploadPath);
            }

            List<(string filename, string path)> datas = new();
            List<bool> results = new();
            foreach (IFormFile file in files)
            {
                string fileName = await RenameFileAsync(file.FileName);
                bool result = await CopyFileAsync(fileName);
                datas.Add((fileName, $"{uploadPath}//{fileName}"));
                results.Add(result);
            }
            if(results.TrueForAll(r=> r.Equals(true)))
            return datas;
            //todo burada fayllarin geri donmesinde false netice gelme ehtiyatina dair exception gondermek lazimdir
        }
    }
}
