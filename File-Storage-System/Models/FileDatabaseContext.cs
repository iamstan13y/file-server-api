using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace File_Storage_System.Models
{
    public class FileDatabaseContext: DbContext
    {
        public FileDatabaseContext(DbContextOptions<FileDatabaseContext> options)
        :base(options)
        {

        }

        public DbSet<FileUpload> FileUpload { get; set; }
    }
}
