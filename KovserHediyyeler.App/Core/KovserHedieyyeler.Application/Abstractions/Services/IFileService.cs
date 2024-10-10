using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Abstractions.Services
{
    public interface IFileService
    {
        Task<List<(string filename, string path)>> UploadFileAsync(string path, IFormFileCollection files);
        Task<bool> CopyFileAsync(string path);
    }
}
