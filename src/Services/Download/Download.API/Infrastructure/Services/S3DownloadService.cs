using Amazon.S3;
using Download.API.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Download.API.Infrastructure.Services
{
    public class S3DownloadService : IDownloadService
    {
        private AmazonS3Client _awsClient;
        private S3Config _s3Config;

        public S3DownloadService(AmazonS3Client awsClient, IOptions<S3Config> options)
        {
            _awsClient = awsClient;
            _s3Config = options.Value;
        }
        public async Task<Stream> DownloadAsync(string objectName)
        {
            var result = await _awsClient.GetObjectAsync(_s3Config.BucketNameStorage, objectName);
            return result.ResponseStream; ;
        }
    }
}
