using MediatR;

namespace File.API.Application.Commands
{
    public class DeleteFileCommand: IRequest<bool>
    {
        public int Id { get; set; }
    }
}
