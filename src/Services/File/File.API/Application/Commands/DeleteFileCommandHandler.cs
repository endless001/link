using File.API.Infrastructure.Idempotency;
using File.Domain.AggregatesModel;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace File.API.Application.Commands
{
    public class DeleteFileCommandHandler : IRequestHandler<DeleteFileCommand, bool>
    {

        private readonly IFileRepository _fileRepository;
        public DeleteFileCommandHandler(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }
        public async Task<bool> Handle(DeleteFileCommand request, CancellationToken cancellationToken)
        {
            var file = await _fileRepository.GetAsync(request.Id);

            if (file == null)
            {
                return false;
            }

            file.DeleteFile();
            return await _fileRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
    public class DeleteFileCommandIdentifiedCommandHandler : IdentifiedCommandHandler<DeleteFileCommand, bool>
    {
        public DeleteFileCommandIdentifiedCommandHandler(
            IMediator mediator,
            IRequestManager requestManager,
            ILogger<IdentifiedCommandHandler<DeleteFileCommand, bool>> logger)
            : base(mediator, requestManager, logger)
        { }

        protected override bool CreateResultForDuplicateRequest()
        {
            return true;
        }
    }
}
