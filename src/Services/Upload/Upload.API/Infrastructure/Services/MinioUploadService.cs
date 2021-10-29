using Microsoft.Extensions.Options;
using Minio;
using StackExchange.Redis;
using System.IO;
using System.Threading.Tasks;
using Upload.API.Configuration;

namespace Upload.API.Infrastructure.Services
{
    public class MinioUploadService : IUploadService
    {
        private readonly MinioClient _client;
        private readonly ConnectionMultiplexer _redis;
        private readonly IDatabase _database;
        private readonly StorageConfig _storageConfig;
        public MinioUploadService(MinioClient client, ConnectionMultiplexer redis, IOptions<StorageConfig> options)
        {
            _client = client; 
            _redis = redis;
            _database = redis.GetDatabase();
            _storageConfig = options.Value;

        }
        public Task<bool> CompleteMultipartUpload(string objectName, string uploadId)
        {
            throw new System.NotImplementedException();
        }

        public  Task<string> GetFileHash(string objectName)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> InitiateMultipartUpload(string objectName)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> MultipartUpload(string objectName, string uploadId, Stream content, int index, long size)
        {
            throw new System.NotImplementedException();
        }

        public async  Task<bool> Upload(string objectName, Stream content)
        {
            if (!await _client.BucketExistsAsync(_storageConfig.BucketStorageName))
            {
                await _client.MakeBucketAsync(_storageConfig.BucketStorageName);
            }

            await _client.PutObjectAsync(_storageConfig.BucketStorageName, objectName, content, content.Length);
            return true;
        }

        public async Task<bool> UploadUserPhoto(string objectName, Stream content)
        {
            if (!await _client.BucketExistsAsync(_storageConfig.BucketUserPhotoName))
            {
                await _client.MakeBucketAsync(_storageConfig.BucketUserPhotoName);
            }

            await  _client.PutObjectAsync(_storageConfig.BucketUserPhotoName, objectName, content, content.Length);
            return true;
        }
      
    }
}
