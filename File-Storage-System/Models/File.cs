using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace File_Storage_System.Models
{
    public class File
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; }
        public string ApplicationId { get; set; }
        public string Url { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
