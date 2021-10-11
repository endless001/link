using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace File.API.Application.Queries
{
    public record File
    {
        public string FileHash  { get; init; }
        public string FileName  { get; init; }
        public string ParentPath  { get; init; }
        public long FileSize  { get; init; }
        public int UserId  { get; init; }
        public bool IsDirectory  { get; init; }
        public FileType FileType  { get; init; }
        public FileStatus FileStatus  { get; init; }
        public DateTime CreateTime  { get; init; }
        public DateTime UpdateTime  { get; init; }
    }

    public record FileType
    {
        public int Id { get; init; }
        public string Name { get; init; }
    }
    
    public record FileStatus
    {
        public int Id { get; init; }
        public string Name { get; init; }
    }
}
