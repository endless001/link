using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Upload.API.Infrastructure.Services;

namespace Upload.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UploadController : ControllerBase
    {
      
        private readonly ILogger<UploadController> _logger;
        private readonly IUploadService _uploadService;
        public UploadController(ILogger<UploadController> logger, Func<string, IUploadService> funcFactory)
        {
            _logger = logger;
            _uploadService = funcFactory("Minio");
        }
     
        [HttpPost("uploaduserphoto")]
        public async Task<IActionResult> UploadUserPhoto()
        {

            var file = Request.Form.Files.FirstOrDefault();
            if (file == null)
            {
                return BadRequest();
            }
            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim();
            var newName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(fileName)}";

            await using (var stream = file.OpenReadStream())
            {
                await _uploadService.UploadUserPhoto(newName, stream);
            }

            return Ok();

        }

        [HttpPost()]
        public async Task<IActionResult> Upload([FromQuery] string parentPath)
        {

            var file = Request.Form.Files.FirstOrDefault();
            if (file == null)
            {
                return BadRequest();
            }
  
            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim();
            var newName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(fileName)}";
            await using (var stream = file.OpenReadStream())
            {
                await _uploadService.Upload(newName, stream);
            }

            var fileHash = await _uploadService.GetFileHash(newName);

            return Ok();
        }
      
        [HttpPost("initiatemultipartupload")]
        public async Task<IActionResult> InitiateMultipartUpload([FromQuery] string fileName)
        {
            var newName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(fileName)}";
            var uploadId =  await _uploadService.InitiateMultipartUpload(newName);
            var result = new { FileName = newName, UploadId = uploadId };
            return Ok(result);
        }
   
        [HttpPost("completemultipartupload")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CompleteMultipartUpload([FromQuery] string fileName, [FromQuery] string uploadId)
        {
            var result = await _uploadService.CompleteMultipartUpload(fileName, uploadId);
            return result ? Ok() : BadRequest();
        }
       
        [HttpPost("multipartupload")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> MultipartUpload([FromQuery] string fileName,[FromQuery] string uploadId,[FromQuery]int chunk)
        {
            var file =  Request.Form.Files.FirstOrDefault();
            if (file == null)
            {
                return BadRequest();
            }

            await using var stream = file.OpenReadStream();
            var result = await _uploadService.MultipartUpload(fileName, uploadId, stream, chunk, stream.Length);
            return result ? Ok() : BadRequest();

        }
    }
}
