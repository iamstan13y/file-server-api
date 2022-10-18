using FileServer.API.Models.Data;
using FileServer.API.Models.Local;
using FileServer.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FileServer.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FilesController(IFileService fileService) => _fileService = fileService;

        [HttpPost("upload")]
        [ProducesResponseType(typeof(Result<JFile>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<JFile>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadFileAsync(IFormFile file)
        {
            var result = await _fileService.UploadFileAsync(file);

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }
    }
}