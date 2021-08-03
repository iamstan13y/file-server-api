using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace File_Storage_System.Models
{
    [Table("Files")]
    public class FileUpload
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FileName { get; set; }
        public string ApplicationId { get; set; }
        public string Url { get; set; }
        public DateTime? DateCreated { get; set; }

    }
}
