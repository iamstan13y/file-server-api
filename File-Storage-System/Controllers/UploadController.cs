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
        [HttpPost]
        private async Task<IActionResult> UploadFile(IFormFile file, string applicationId)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory() + "\\Files\\");
            var fileName = Path.GetFileName(file.FileName);
            var url = Path.Combine($"{basePath}{DateTime.Now.Ticks}", fileName);

                using (var stream = new FileStream(url, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                var newFile = new FileUpload
                {
                    FileName = fileName,
                    Url= url,
                    ApplicationId = applicationId,
                    DateCreated = DateTime.Now.Date
                };

                context.FilesOnFileSystem.Add(newFile);
                context.SaveChanges();
            }
        }
    }
}
