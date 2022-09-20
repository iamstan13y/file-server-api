using System;

namespace FileServer.API.Models.Data
{
    public class JFile
    {
        public int Id { get; set; }
        public string? FileName { get; set; }
        public string? FileType { get; set; }
        public long FileSize { get; set; }
        public string? Path { get; set; }
        public string? Url { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}