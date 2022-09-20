using System.Collections.Generic;

namespace FileServer.API.Models.Local
{
    public class Result<T>
    {
        public Result() { }
        
        public Result(T Data) => this.Data = Data;
        
        public Result(bool Success, string Message)
        {
            this.Success = Success;
            this.Message = Message;
        }

        public Result(bool Success, T Data, string Message)
        {
            this.Success = Success;
            this.Data = Data;
            this.Message = Message;
        }

        public Result(T Data, string Message)
        {
            this.Data = Data;
            this.Message = Message;
        }

        public bool Success { get; set; } = true;
        public T? Data { get; set; }
        public string? Message { get; set; }
    }
}