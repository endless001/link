using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Download.API.Infrastructure.Services
{
    public interface IDownloadService
    {
        Task<Stream> DownloadAsync(string objectName);
    }
}
