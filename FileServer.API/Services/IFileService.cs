using FileServer.API.Models.Data;
using FileServer.API.Models.Local;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace FileServer.API.Services
{
    public interface IFileService
    {
        Task<Result<JFile>> UploadFileAsync(IFormFile formFile);
        Task<Result<bool>> DeleteFileAsync(string fileName);
    }
}