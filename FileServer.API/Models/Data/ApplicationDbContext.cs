using Microsoft.EntityFrameworkCore;

namespace FileServer.API.Models.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
	public DbSet<JFile>? Files { get; set; }
}