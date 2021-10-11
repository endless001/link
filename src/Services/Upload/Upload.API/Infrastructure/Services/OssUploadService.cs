using Aliyun.OSS;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Upload.API.Configuration;
using Upload.API.Models;

namespace Upload.API.Infrastructure.Services
{
    public class OssUploadService : IUploadService
    {
        private readonly OssClient _ossClient;
        private readonly OssConfig _ossConfig;

        private readonly ConnectionMultiplexer _redis;
        private readonly IDatabase _database;
        public OssUploadService(OssClient ossClient, ConnectionMultiplexer redis, IOptions<OssConfig> options)
        {
            _ossClient = ossClient;
            _ossConfig = options.Value;
            _redis = redis;
            _database = redis.GetDatabase();
        }

        public async Task<bool> CompleteMultipartUpload(string objectName, string uploadId)
        {

            if (!BucketExist(_ossConfig.BucketNameStorage))
            {
                CreateBucket(_ossConfig.BucketNameStorage);
            }

            var completeMultipartUploadRequest = new CompleteMultipartUploadRequest(_ossConfig.BucketNameStorage, objectName, uploadId);
            var value = await _database.ListRangeAsync(uploadId);
            var partTags = value.Select(v => JsonSerializer.Deserialize<PartTag>(Encoding.UTF8.GetString(v)));
            completeMultipartUploadRequest.PartETags.ToList().AddRange(
                    partTags.OrderBy(a => a.PartNumber).Select(p =>
                    new PartETag(p.PartNumber, p.ETag, p.Crc64, p.Length)));

            var result = _ossClient.CompleteMultipartUpload(completeMultipartUploadRequest);
            return await Task.FromResult(true);
        }

        public Task<string> GetFileHash(string objectName)
        {
            var result = _ossClient.GetObjectMetadata(_ossConfig.BucketNameStorage, objectName);
            return Task.FromResult(result.ETag);
        }

        public Task<string> InitiateMultipartUpload(string objectName)
        {
            if (!BucketExist(_ossConfig.BucketNameUserPhoto))
            {
                CreateBucket(_ossConfig.BucketNameStorage);
            }
            var request = new InitiateMultipartUploadRequest(_ossConfig.BucketNameStorage, objectName);
            var result = _ossClient.InitiateMultipartUpload(request);
            return Task.FromResult(result.UploadId);
        }

        public async Task<bool> MultipartUpload(string objectName, string uploadId, Stream content, int index, long size)
        {
            if (!BucketExist(_ossConfig.BucketNameStorage))
            {
                CreateBucket(_ossConfig.BucketNameStorage);
            }

            var request = new UploadPartRequest(_ossConfig.BucketNameStorage, objectName, uploadId)
            {
                InputStream = content,
                PartSize = size,
                PartNumber = index + 1,
            };

            var result = await Task.Factory.FromAsync(_ossClient.BeginUploadPart, _ossClient.EndUploadPart, request, string.Empty);
            await _database.ListRightPushAsync(uploadId, JsonSerializer.Serialize(result.PartETag));
            return true;
        }

        public async Task<bool> Upload(string objectName, Stream content)
        {
            if (!BucketExist(_ossConfig.BucketNameStorage))
            {
                CreateBucket(_ossConfig.BucketNameStorage);
            }
            var result = await Task.Factory.FromAsync(_ossClient.BeginPutObject, _ossClient.EndPutObject,
                _ossConfig.BucketNameStorage, objectName, content, string.Empty);
            return true;
        }

        public async Task<bool> UploadUserPhoto(string objectName, Stream content)
        {
            if (!BucketExist(_ossConfig.BucketNameUserPhoto))
            {
                CreateBucket(_ossConfig.BucketNameUserPhoto);
            }

            var result = await Task.Factory.FromAsync(_ossClient.BeginPutObject, _ossClient.EndPutObject,
                 _ossConfig.BucketNameUserPhoto, objectName, content, string.Empty);
            return true;
        }

        private void CreateBucket(string bucketName)
        {
            _ossClient.CreateBucket(bucketName);
        }
        private bool BucketExist(string bucketName)
        {
            return _ossClient.DoesBucketExist(bucketName);
        }
    }
}
