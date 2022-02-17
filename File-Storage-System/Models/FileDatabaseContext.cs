using Microsoft.EntityFrameworkCore;

namespace File_Storage_System.Models
{
    public class FileDatabaseContext: DbContext
    {
        public FileDatabaseContext(DbContextOptions<FileDatabaseContext> options)
        :base(options)
        {

        }

        public DbSet<FileUpload> FileUpload { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}
