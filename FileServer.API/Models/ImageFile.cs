namespace FileServer.API.Models
{
    public class ImageFile
    {
        public int Id { get; set; }
        public string? FileName { get; set; }
        public string? Path { get; set; }
        public string? Url { get; set; }
    }
}