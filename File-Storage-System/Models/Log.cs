using System;

namespace File_Storage_System.Models
{
    public class Log
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string MessageTemplate { get; set; }
        public string Level { get; set; }
        public DateTime Timestamp { get; set; }
        public string Exception { get; set; }
        public string Properties { get; set; } //XML Properties
        public string LogEvent { get; set; }
    }
}
