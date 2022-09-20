using FileServer.API.Models.Data;
using FileServer.API.Models.Local;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileServer.API.Models.Repository
{
    public class FileRepository : IFileRepository
    {
        private readonly ApplicationDbContext _context;

        public FileRepository(ApplicationDbContext context) => _context = context;

        public async Task<Result<JFile>> AddAsync(JFile imageFile)
        {
            await _context.Files!.AddAsync(imageFile);
            await _context.SaveChangesAsync();

            return new Result<JFile>(imageFile);
        }

        public async Task<Result<bool>> DeleteAsync(string fileName)
        {
            var file = await _context.Files!.Where(x => x.FileName == fileName).FirstOrDefaultAsync();
            if (file == null) return new Result<bool>(false, "File record not found.");

            _context.Files!.Remove(file);
            await _context.SaveChangesAsync();

            return new Result<bool>(true);
        }

        public async Task<Result<IEnumerable<JFile>>> GetAllAsync()
        {
            var files = await _context.Files!.ToListAsync();
            return new Result<IEnumerable<JFile>>(files);
        }
    }
}