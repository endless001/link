using File.API.Infrastructure.Idempotency;
using File.Domain.AggregatesModel;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace File.API.Application.Commands
{
    public class RenameFileCommandHandler : IRequestHandler<RenameFileCommand, bool>
    {
        private readonly IFileRepository _fileRepository;
        public RenameFileCommandHandler(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public async Task<bool> Handle(RenameFileCommand request, CancellationToken cancellationToken)
        {
            var file = await _fileRepository.GetAsync(request.Id);

            if (file == null)
            {
                return false;
            }
            file.RenameFile(request.FileName);
            return await _fileRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
    public class RenameFileCommandIdentifiedCommandHandler : IdentifiedCommandHandler<RenameFileCommand, bool>
    {
        public RenameFileCommandIdentifiedCommandHandler(
            IMediator mediator,
            IRequestManager requestManager,
            ILogger<IdentifiedCommandHandler<RenameFileCommand, bool>> logger)
            : base(mediator, requestManager, logger)
        { }
        
        protected override bool CreateResultForDuplicateRequest()
        {
            return true;
        }
    }
}
