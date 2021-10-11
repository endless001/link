using MediatR;
using System.Runtime.Serialization;

namespace File.API.Application.Commands
{
    [DataContract]
    public class CreateFileCommand : IRequest<bool>
    {
        [DataMember]
        public string FileHash { get; set; }

        [DataMember]
        public string FileName { get; set; }

        [DataMember]
        public string ParentPath { get; set; }

        [DataMember]
        public long FileSize { get; set; }

        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public bool IsDirectory { get; set; }
    }
}
