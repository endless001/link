using Aliyun.OSS;
using Download.API.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Download.API.Infrastructure.Services
{
    public class OssDownloadService : IDownloadService
    {
        private readonly OssClient _ossClient;
        private readonly OssConfig _ossConfig;

        public OssDownloadService(OssClient ossClient, IOptions<OssConfig> options)
        {
            _ossClient = ossClient;
            _ossConfig = options.Value;
        }

        public async Task<Stream> DownloadAsync(string objectName)
        {
            var ossObject = await Task.Factory.FromAsync(_ossClient.BeginGetObject, _ossClient.EndGetObject,
             _ossConfig.BucketNameStorage, objectName, string.Empty);
            return ossObject.Content;
        }
    }
}
