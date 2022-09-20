using FileServer.API.Models.Data;
using FileServer.API.Models.Local;
using FileServer.API.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace FileServer.API.Services
{
    public class FileService : IFileService
    {
        private readonly IConfiguration _configuration;
        private readonly IFileRepository _fileRepository;

        public FileService(IConfiguration configuration, IFileRepository fileRepository)
        {
            _configuration = configuration;
            _fileRepository = fileRepository;
        }

        public async Task<Result<JFile>> UploadFileAsync(IFormFile file)
        {
            try
            {
                string basePath = Path.Combine(Directory.GetCurrentDirectory() + "/uploads/");
                string fileName = Path.GetFileName(file.FileName);
                string newFileName = string.Concat($"JFILE-{DateTime.Now.Ticks.ToString()[12..]}-", fileName);
                string filePath = string.Concat($"{basePath}", newFileName);

                string url = $"{_configuration["Urls:DevBaseUrl"]}/uploads/{newFileName}";
                using (var stream = new FileStream(filePath, FileMode.Create))
                await file.CopyToAsync(stream);

                var result = await _fileRepository.AddAsync(new JFile
                {
                    FileName = newFileName,
                    Url = url,
                    Path = filePath,
                    FileSize = file.Length,
                    FileType = file.ContentType
                });

                return result;
            }
            catch (Exception ex)
            {
                return new Result<JFile>(false, ex.ToString());
            }
        }
    }
}