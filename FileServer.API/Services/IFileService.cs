using FileServer.API.Models.Data;
using ModelLibrary;

namespace FileServer.API.Services
{
    public interface IFileService
    {
        Task<Result<JFile>> UploadFileAsync(IFormFile formFile);
        Task<Result<bool>> DeleteFileAsync(string fileName);
    }
}