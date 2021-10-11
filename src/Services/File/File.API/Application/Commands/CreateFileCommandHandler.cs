using File.API.Infrastructure.Idempotency;
using File.Domain.AggregatesModel;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FileEntity = File.Domain.AggregatesModel.File;

namespace File.API.Application.Commands
{
    public class CreateFileCommandHandler : IRequestHandler<CreateFileCommand, bool>
    {
        private readonly IFileRepository _fileRepository;
        public CreateFileCommandHandler(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public async Task<bool> Handle(CreateFileCommand request, CancellationToken cancellationToken)
        {
            var file = new FileEntity();
            _fileRepository.Add(file);
            return await _fileRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }

    }
    public class CreateFileIdentifiedCommandHandler : IdentifiedCommandHandler<CreateFileCommand, bool>
    {
        public CreateFileIdentifiedCommandHandler(
            IMediator mediator,
            IRequestManager requestManager,
            ILogger<IdentifiedCommandHandler<CreateFileCommand, bool>> logger)
            : base(mediator, requestManager, logger)
        {
        }

        protected override bool CreateResultForDuplicateRequest()
        {
            return true; 
        }
    }
}
