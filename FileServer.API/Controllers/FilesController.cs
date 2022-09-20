using FileServer.API.Models;
using FileServer.API.Models.Repository;
using FileServer.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelLibrary;

namespace FileServer.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IFileRepository _fileRepository;

        public FilesController(IFileService fileService, IFileRepository fileRepository)
        {
            _fileService = fileService;
            _fileRepository = fileRepository;
        }

        [HttpPost("upload-file")]
        [Authorize]
        [ProducesResponseType(typeof(Result<ImageFile>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<ImageFile>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadFileAsync(IFormFile file)
        {
            var result = await _fileService.UploadFileAsync(file);

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _fileRepository.GetAllAsync());

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] string fileName) => Ok(await _fileService.DeleteFileAsync(fileName));
    }
}