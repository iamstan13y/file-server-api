using FileServer.API.Models.Data;
using Microsoft.EntityFrameworkCore;
using ModelLibrary;

namespace FileServer.API.Models.Repository
{
    public class FileRepository : IFileRepository
    {
        private readonly ApplicationDbContext _context;

        public FileRepository(ApplicationDbContext context) => _context = context;

        public async Task<Result<JFile>> AddAsync(JFile imageFile)
        {
            await _context.ImageFiles!.AddAsync(imageFile);
            await _context.SaveChangesAsync();

            return new Result<JFile>(imageFile);
        }

        public async Task<Result<bool>> DeleteAsync(string fileName)
        {
            var file = await _context.ImageFiles!.Where(x => x.FileName == fileName).FirstOrDefaultAsync();
            if (file == null) return new Result<bool>(false, new List<string> { "File record not found." });

            _context.ImageFiles!.Remove(file);
            await _context.SaveChangesAsync();

            return new Result<bool>(true);
        }

        public async Task<Result<IEnumerable<JFile>>> GetAllAsync()
        {
            var files = await _context.ImageFiles!.ToListAsync();
            return new Result<IEnumerable<JFile>>(files);
        }
    }
}