using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Upload.API.Infrastructure.Services
{
    public interface IUploadService
    {
        Task<bool> Upload(string objectName, Stream content);
        Task<bool> UploadUserPhoto(string objectName, Stream content);
        Task<string> InitiateMultipartUpload(string objectName);
        Task<bool> MultipartUpload(string objectName, string uploadId, Stream content, int index, long size);
        Task<bool> CompleteMultipartUpload(string objectName, string uploadId);
        Task<string> GetFileHash(string objectName);
    }
}
