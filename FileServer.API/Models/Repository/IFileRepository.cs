using FileServer.API.Models.Data;
using ModelLibrary;

namespace FileServer.API.Models.Repository
{
    public interface IFileRepository
    {
        Task<Result<JFile>> AddAsync(JFile imageFile);
        Task<Result<IEnumerable<JFile>>> GetAllAsync();
        Task<Result<bool>> DeleteAsync(string fileName);
    }
}