using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace File.API.Application.Commands
{
    public class MoveFileCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Path { get; set; }
    }
}
