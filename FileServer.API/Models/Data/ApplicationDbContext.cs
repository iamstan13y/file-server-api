using Microsoft.EntityFrameworkCore;

namespace FileServer.API.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<JFile>? ImageFiles { get; set; }
    }
}