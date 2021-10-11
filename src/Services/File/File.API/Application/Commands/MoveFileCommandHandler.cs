using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using File.API.Infrastructure.Idempotency;
using File.Domain.AggregatesModel;

namespace File.API.Application.Commands
{
    public class MoveFileCommandHandler : IRequestHandler<MoveFileCommand, bool>
    {
        private readonly IFileRepository _fileRepository;
        public MoveFileCommandHandler(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }
        public async Task<bool> Handle(MoveFileCommand request, CancellationToken cancellationToken)
        {
            var file = await _fileRepository.GetAsync(request.Id);

            if (file == null)
            {
                return false;
            }

            file.MoveFile(request.Path);
            return await _fileRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
    public class MoveFileCommandIdentifiedCommandHandler : IdentifiedCommandHandler<MoveFileCommand, bool>
    {
        public MoveFileCommandIdentifiedCommandHandler(
            IMediator mediator,
            IRequestManager requestManager,
            ILogger<IdentifiedCommandHandler<MoveFileCommand, bool>> logger)
            : base(mediator, requestManager, logger)
        {}

        protected override bool CreateResultForDuplicateRequest()
        {
            return true;                
        }
    }
}
