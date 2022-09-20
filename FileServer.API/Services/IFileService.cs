using FileServer.API.Models;
using ModelLibrary;

namespace FileServer.API.Services
{
    public interface IFileService
    {
        Task<Result<ImageFile>> UploadFileAsync(IFormFile formFile);
        Task<Result<bool>> DeleteFileAsync(string fileName);
    }
}