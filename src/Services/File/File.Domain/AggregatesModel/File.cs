using File.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File.Domain.AggregatesModel
{
    public class File : Entity, IAggregateRoot
    {
        public string FileHash { get; set; }
        public string FileName { get; set; }
        public string ParentPath { get; set; }
        public long FileSize { get; set; }
        public int UserId { get; set; }
        public bool IsDirectory { get; set; }
        public FileType FileType { get; set; }
        public FileStatus FileStatus { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }

        private int _fileStatusId;
        private int _fileTypeId;

        public File()
        {
            _fileStatusId = FileStatus.Normal.Id;
            _fileTypeId = FileType.Other.Id;
        }
        public void RenameFile(string fileName)
        {
            this.FileName = fileName;
        }

        public void MoveFile(string parentPath)
        {
            this.ParentPath = parentPath;
        }

        public void DeleteFile()
        {
            this._fileStatusId = FileStatus.Deleted.Id;
        }
    }
}
