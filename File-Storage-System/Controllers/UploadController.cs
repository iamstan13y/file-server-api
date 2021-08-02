using File_Storage_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace File_Storage_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly FileDatabaseContext _context;

        public UploadController(FileDatabaseContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(IFormFile file, string applicationId)
        {
            string basePath = Path.Combine(Directory.GetCurrentDirectory() + "\\Files\\");
            string fileName = Path.GetFileName(file.FileName);
            string newFileName = string.Concat($"{DateTime.Now.Ticks}", fileName);
            string filePath = string.Concat($"{basePath}", newFileName);

            string url = $"{ApiData.BaseURL}Files/{newFileName}";
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var newFile = new FileUpload
                {
                    FileName = fileName,
                    Url= url,
                    ApplicationId = applicationId,
                    DateCreated = DateTime.Now
                };

                _context.FileUpload.Add(newFile);
                _context.SaveChanges();

            return Ok(url);
        }
    }
}
