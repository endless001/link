using MediatR;

namespace File.API.Application.Commands
{
    public class RenameFileCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string FileName { get; set; }
    }
}
