using ModelLibrary;

namespace FileServer.API.Models.Repository
{
    public interface IFileRepository
    {
        Task<Result<ImageFile>> AddAsync(ImageFile imageFile);
        Task<Result<IEnumerable<ImageFile>>> GetAllAsync();
        Task<Result<bool>> DeleteAsync(string fileName);
    }
}