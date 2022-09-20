using FileServer.API.Models.Data;
using FileServer.API.Models.Local;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServer.API.Models.Repository
{
    public interface IFileRepository
    {
        Task<Result<JFile>> AddAsync(JFile file);
        Task<Result<IEnumerable<JFile>>> GetAllAsync();
        Task<Result<bool>> DeleteAsync(string fileName);
    }
}