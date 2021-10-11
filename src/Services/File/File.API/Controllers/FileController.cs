using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using File.API.Application.Commands;
using File.API.Application.Queries;
using File.API.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace File.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class FileController : BaseController
    {

        private readonly IMediator _mediator;
        private readonly IFileQueries _fileQueries;
        private readonly ILogger<FileController> _logger;

        public FileController(IMediator mediator, IFileQueries fileQueries, ILogger<FileController> logger)
        {
            _mediator = mediator;
            _fileQueries = fileQueries;
            _logger = logger;
        }

        [Route("myfiles")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Application.Queries.File>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetFiles([FromQuery] string currentDirectory, [FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 0)
        {
            var result = await _fileQueries.GetFilesFromUserAsync(AccountId,
                currentDirectory);
            return Ok(result);
        }

        [Route("myfolders")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Application.Queries.File>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetFolders([FromQuery] string currentDirectory, [FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 0)
        {
            var result = await _fileQueries.GetFoldersFromUserAsync(AccountId,
                currentDirectory);
            return Ok(result);
        }

        [Route("createfile")]
        [HttpPost]
        public async Task<IActionResult> CreateFile([FromBody] CreateFileCommand command, [FromHeader(Name = "x-requestid")] string requestId)
        {

            _logger.LogInformation(
                 "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                 command.GetGenericTypeName(),
                 nameof(command.UserId),
                 command.UserId,
                 command);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        
        [Route("movefile")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> MoveFile([FromBody] MoveFileCommand command, [FromHeader(Name = "x-requestid")] string requestId)
        {

            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                command.GetGenericTypeName(),
                nameof(command.Id),
                command.Id,
                command);
            
            var result = await _mediator.Send(command);
            return Ok(result);
        } 
        
        [Route("renamefile")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RenameFile([FromBody] RenameFileCommand command, [FromHeader(Name = "x-requestid")] string requestId)
        {

            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                command.GetGenericTypeName(),
                nameof(command.Id),
                command.Id,
                command);
            
            var result = await _mediator.Send(command);
            return Ok(result);
        } 
        
        [Route("deletefile")]
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteFile([FromBody] DeleteFileCommand command, [FromHeader(Name = "x-requestid")] string requestId)
        {

            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                command.GetGenericTypeName(),
                nameof(command.Id),
                command.Id,
                command);
            
            var result = await _mediator.Send(command);
            return Ok(result);
        } 

    }
}
