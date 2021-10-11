using File.API.Infrastructure.Extensions;
using File.API.Infrastructure.Idempotency;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace File.API.Application.Commands
{
    public class IdentifiedCommandHandler<T, R> : IRequestHandler<IdentifiedCommand<T, R>, R>
          where T : IRequest<R>
    {

        private readonly IMediator _mediator;
        private readonly IRequestManager _requestManager;
        private readonly ILogger<IdentifiedCommandHandler<T, R>> _logger;


        public IdentifiedCommandHandler(
           IMediator mediator,
           IRequestManager requestManager,
           ILogger<IdentifiedCommandHandler<T, R>> logger)
        {
            _mediator = mediator;
            _requestManager = requestManager;
            _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
        }
        protected virtual R CreateResultForDuplicateRequest()
        {
            return default(R);
        }

        public async Task<R> Handle(IdentifiedCommand<T, R> message, CancellationToken cancellationToken)
        {

            var alreadyExists = await _requestManager.ExistAsync(message.Id);
            if (alreadyExists)
            {
                return CreateResultForDuplicateRequest();
            }
            else
            {
                await _requestManager.CreateRequestForCommandAsync<T>(message.Id);
                try
                {
                    var command = message.Command;
                    var commandName = command.GetGenericTypeName();
                    var idProperty = string.Empty;
                    var commandId = string.Empty;
                    switch (command)
                    {
                        case CreateFileCommand createFileCommand:
                            idProperty = nameof(createFileCommand.UserId);
                            commandId = $"{createFileCommand.UserId}";
                            break;

                        case DeleteFileCommand deleteFileCommand:
                            idProperty = nameof(deleteFileCommand.Id);
                            commandId = $"{deleteFileCommand.Id}";
                            break;

                        case RenameFileCommand renameFileCommand:
                            idProperty = nameof(renameFileCommand.Id);
                            commandId = $"{renameFileCommand.Id}";
                            break;

                        case MoveFileCommand deleteFileCommand:
                            idProperty = nameof(deleteFileCommand.Id);
                            commandId = $"{deleteFileCommand.Id}";
                            break;

                        default:
                            idProperty = "Id?";
                            commandId = "n/a";
                            break;
                    }

                    _logger.LogInformation(
                        "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                        commandName,
                        idProperty,
                        commandId,
                        command);

                    // Send the embeded business command to mediator so it runs its related CommandHandler 
                    var result = await _mediator.Send(command, cancellationToken);

                    _logger.LogInformation(
                        "----- Command result: {@Result} - {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                        result,
                        commandName,
                        idProperty,
                        commandId,
                        command);

                    return result;
                }
                catch
                {
                    return default(R);
                }
            }
        }
    }
}
